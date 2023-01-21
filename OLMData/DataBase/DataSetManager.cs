using Microsoft.SqlServer.Server;
using OLMServer.OLMData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AdvancedDatasetManager
{
    public static class DataSetManager
    {
        public static readonly Dictionary<string, string> dataTypes = new Dictionary<string, string>()
        {
            { "str", "String" },
            { "flt", "Float" },
            { "int", "Integer" },
            { "dec", "Decimal" },
            { "lst", "Array" },
            { "lnk", "Dataset Link" },
            { "bag", "Dataset Bag" },
            { "pth", "Path" },
            { "var", "Dynamic" },
        };

        public static Dictionary<string, dynamic> data = new Dictionary<string, dynamic>();

        public static void AddDataToTable(Dictionary<string, dynamic> data, string tableName)
        {
            foreach (string tableData in DataSetManager.data["tables"])
            {
                string tableNm = tableData;
                if (tableNm == tableName)
                {
                    string tablePath = new FileInfo(tableNm).Directory.Name;
                    var dataset = ReadDataSet(DataPath + "/" + tablePath);
                    dataset[dataset["length"]] = DataPath + "/" + new FileInfo(tablePath).Directory.Name + "/tableMember" + dataset["length"] + ".inf";
                    dataset["length"] += 1;

                    ChangeValueOfDataSet(DataPath + "/" + tablePath, "length", dataset["length"]);

                    AddDataToDataSet(DataPath + "/" + tablePath, "length", dataset["length"]);

                    WriteDataSet(DataPath + "/" + new FileInfo(tablePath).Directory.Name + "/tableMember" + dataset["length"] + ".inf", data);

                    return;
                }
            }
            throw new Exception($"No table named as {tableName} (TODO)");
        }

        public static string DataPath;
        public static void Init(string dataPath, string name)
        {
            DataPath = dataPath;
            if (!Directory.Exists(dataPath))
            {
                Directory.CreateDirectory(dataPath);
            }
            if (!File.Exists(dataPath + "/dbinf.dsl"))
            {
                WriteDataSet(dataPath + "/dbinf.dsl", new Dictionary<string, dynamic>()
                {
                    { "type", "DataBaseInfo" },
                    { "name", name },
                    { "tables", new string[] { "Users", "Books" } },
                    { "lnk:UsersTBL", "Users/tableinf.ads" },
                    { "lnk:BooksTBL", "Books/tableinf.ads" }
                });
                Init(dataPath, name);
            }
            else
            {
                data = ReadDataSet(dataPath + "/dbinf.dsl");
                if (!data.ContainsKey("type") || data["type"] != "DataBaseInfo")
                    throw new Exception("Wrong file type (File must be include type) (TODO)");
                if (!data.ContainsKey("name"))
                    throw new Exception("Wrong file type (File must be include name) (TODO)");
                if (!data.ContainsKey("tables"))
                    throw new Exception("Wrong file type (File must be include tables) (TODO)");
                foreach (string tableName in data["tables"])
                    if (!data.ContainsKey(tableName + "TBL") || !(data[tableName + "TBL"] is DataSet))
                        throw new Exception("Table definitions are wrong (TODD)");

                foreach (string tableData in data["tables"])
                {
                    string tableName = tableData[0].ToString();
                    string tablePath = tableData[1].ToString();
                    if (!File.Exists(DataPath + "/" + tablePath))
                        File.Create(DataPath + "/" + tablePath);
                }
            }
        }

        public static string DetectType(string data)
        {
            if (string.IsNullOrEmpty(data))
                return "emp";
            //throw new Exception("Cannot detect type of empty string (TODO)");

            data = data.Trim();
            float fout;
            decimal dout;
            int iout;
            if (data.StartsWith("\"") && data.EndsWith("\""))
                return "str";
            else if (data.StartsWith("[") && data.EndsWith("]"))
                return "lst";
            else if (data.EndsWith("f") && float.TryParse(data.Remove(data.Length - 1, 1), out fout))
                return "flt";
            else if (data.EndsWith("d") && decimal.TryParse(data.Remove(data.Length - 1, 1), out dout))
                return "dec";
            else if (int.TryParse(data, out iout))
                return "int";
            else if (float.TryParse(data, out fout))
                return "flt";
            else if (data.StartsWith("@\"") && data.EndsWith("\"") && data.Remove(data.Length - 1, 1).Trim().EndsWith(".ads"))
                return "lnk";
            else if (data.StartsWith("@\"") && data.EndsWith("\""))
                return "pth";
            throw new Exception($"Detect Type Error: Undefined type! (TODO) [{data}]");
        }

        public static dynamic ParseValue(string value, string givenType = null, string datasetPath = null)
        {
            if (string.IsNullOrWhiteSpace(value))
                return "";

            if (string.IsNullOrEmpty(datasetPath))
                datasetPath = DataPath;

            if (string.IsNullOrEmpty(givenType))
                givenType = "var";

            var varType = DetectType(value);
            if (varType == "pth" && givenType == "lnk")
                varType = "lnk";

            if (givenType != "var" && varType != givenType)
                throw new Exception("Wrong type (TODO)");

            value = value.Trim();

            if (varType == "str")
                return value.Remove(value.Length - 1, 1).Remove(0, 1);
            else if (varType == "int")
                return int.Parse(value);
            else if (varType == "flt")
                return float.Parse(value);
            else if (varType == "dec")
                return decimal.Parse(value);
            else if (varType == "lst")
                return ParseList(value);
            else if (varType == "lnk")
                return new DataSet(Path.Combine(Path.Combine(new FileInfo(datasetPath).Directory.FullName, @value.Remove(value.Length - 1, 1).Remove(0, 2))));
            else if (varType == "pth")
                return @value.Remove(value.Length - 1, 1).Remove(0, 2);
            else
                throw new Exception("Parse Value Error: Undefined type (TODO)");
        }

        public static dynamic[] ParseList(string parseText)
        {
            parseText = parseText.Trim();
            if (parseText[0] != '[' || parseText[parseText.Length - 1] != ']')
                throw new Exception("Paarse List: Wrong type (TODO)");
            parseText = parseText.Remove(parseText.Length - 1, 1).Remove(0, 1).Trim();
            var values = new List<string>();
            while (parseText.Contains("[") && parseText.Contains("]"))
            {
                string st1;
                string st2;
                var subList = st1 = parseText.Substring(parseText.IndexOf("["), parseText.IndexOf("]") + 1 - parseText.IndexOf("["));
                if (parseText.IndexOf(",") > parseText.IndexOf("]"))
                {
                    st2 = parseText = parseText.Remove(parseText.IndexOf(",", parseText.IndexOf("]")), 1);
                }
                var ss = parseText.IndexOf("[");
                var se = parseText.IndexOf("]");
                var sf = parseText.IndexOf("]") + 1 - parseText.IndexOf("[");
                parseText = parseText.Remove(parseText.IndexOf("["), parseText.IndexOf("]") + 1 - parseText.IndexOf("["));
                values.Add(subList);
            }
            var vals = parseText.Split(',');
            values.AddRange(vals);
            List<dynamic> lst = new List<dynamic>();
            int i = 0;
            foreach (var v in values)
            {
                if (string.IsNullOrEmpty(v.Trim()))
                    continue;
                lst.Add(ParseValue(v));
                i++;
            }

            return lst.ToArray();
        }

        public static string ChangeValueOfDataSet(string datasetPath, string varName, dynamic varData)
        {
            string[] readData = File.ReadAllLines(datasetPath);
            Dictionary<string, dynamic> output = new Dictionary<string, dynamic>();
            if (readData.Length == 0 || File.ReadAllText(datasetPath).Replace(" ", "") == "")
                throw new Exception("Empty file (TODO)");
            if (readData[0].Trim() != "[DataSet]")
                throw new Exception("Wrong file (TODO)");
            int changeLine = -1;
            string oldData = "";
            var lineNum = 0;
            foreach (string lin in readData)
            {
                if (lin.Replace(" ", "") == "")
                    continue;

                string line = lin.Trim();

                if (line.Split("=")[0].Split(" ")[1].Trim() == varName)
                {
                    line = line.Remove(0, line.Split("=")[0].Length + 1).Trim();
                    changeLine = lineNum;
                    oldData = line;
                }
                lineNum++;
            }
            if (changeLine == -1)
            {
                return null;
            }
            string typ = (DetectType(oldData) == "lnk" && DetectType(varData) == "pth") ? "lnk" : DetectType(varData);
            readData[changeLine] = $"{typ} {varName} = {SerializeData(varData, DetectType(oldData) == "lnk")}";

            File.WriteAllLines(datasetPath, readData);

            return oldData;
        }

        public static string AddDataToDataSet(string datasetPath, string varName, dynamic varData)
        {
            var givenType = "var";
            if (varName.Split(":").Length == 2)
            {
                givenType = varName.Split(":")[0];
                varName = varName.Split(":")[1];
            }
            string[] readData = File.ReadAllLines(datasetPath);
            Dictionary<string, dynamic> output = new Dictionary<string, dynamic>();
            if (readData.Length == 0 || File.ReadAllText(datasetPath).Replace(" ", "") == "")
                throw new Exception("Empty file (TODO)");
            if (readData[0].Trim() != "[DataSet]")
                throw new Exception("Wrong file (TODO)");
            int changeLine = -1;
            string oldData = "";
            var lineNum = 0;
            foreach (string lin in readData)
            {
                if (lin.Replace(" ", "") == "")
                    continue;

                string line = lin.Trim();

                if (line.Split("=")[0].Split(" ")[1].Trim() == varName)
                {
                    line = line.Remove(0, line.Split("=")[0].Length + 1).Trim();
                    changeLine = lineNum;
                    oldData = line;
                }
                lineNum++;
            }
            string typ;
            if (changeLine == -1)
            {
                typ = (DetectType(oldData) == "lnk" && DetectType(varData) == "pth") ? "lnk" : DetectType(varData);
                var newData = new string[readData.Length + 1];
                readData.CopyTo(newData, 0);
                newData[newData.Length-1] = $"{typ} {varName} = {SerializeData(varData, givenType == "lnk")}";

                File.WriteAllLines(datasetPath, readData);
                return null;
            }
            typ = (DetectType(oldData) == "lnk" && DetectType(varData) == "pth") ? "lnk" : DetectType(varData);
            readData[changeLine] = $"{typ} {varName} = {SerializeData(varData, (DetectType(oldData) == "lnk" && givenType != "pth") || givenType == "lnk")}";

            File.WriteAllLines(datasetPath, readData);

            return oldData;
        }

        public static Dictionary<string, dynamic> ReadDataSet(string datasetPath)
        {
            string[] readData = File.ReadAllLines(datasetPath);
            Dictionary<string, dynamic> output = new Dictionary<string, dynamic>();
            if (readData.Length == 0 || File.ReadAllText(datasetPath).Replace(" ", "") == "")
                throw new Exception("Empty file (TODO)");
            if (readData[0].Trim() != "[DataSet]")
                throw new Exception("Wrong file (TODO)");
            readData[0] = "";
            foreach (string lin in readData)
            {
                if (lin.Replace(" ", "") == "")
                    continue;

                string line = lin.Trim();
                if (lin.LastIndexOf("\"") < lin.LastIndexOf(";"))
                {
                    var x = lin.LastIndexOf(';');
                    line = lin.Substring(0, x).Trim();
                    if (line.Replace(" ", "") == "")
                        continue;
                }
                string varDfnt = line.Split('=')[0].Trim();
                while (varDfnt.Contains("  "))
                    varDfnt = varDfnt.Replace("  ", " ");
                var d = line.Split('=')[0];
                line = line.Replace(d, varDfnt + " ");
                if (varDfnt.Split(' ').Length != 2)
                    throw new Exception("Wrong definition (TODO)");
                string varType = varDfnt.Split(' ')[0];
                if (!dataTypes.ContainsKey(varType))
                    throw new Exception("Wrong dataType (TODO)");
                string varName = varDfnt.Split(' ')[1];
                if (line.Split('=').Length == 1)
                {
                    if (varType == "bag")
                    {
                        if (line.Split('.').Length != 1)
                        {
                            if (!output.ContainsKey(varName.Split('.')[0]))
                                throw new Exception("There is no dataset bag named as \"" + varName.Split('.')[0] + "\" (TODO)");
                            else if (output[line.Split('.')[0]] is DataSetBag)
                                throw new Exception("You can't create a dataset bag in a dataset bag (TODO)");
                            else
                                throw new Exception("\"" + varName.Split('.')[0] + "\" isn't a dataset bag, it is a \"" + dataTypes[varType] + "\" (TODO)");
                        }
                        output[varName.Trim()] = new DataSetBag(new Dictionary<string, dynamic>());
                    }
                    else
                        throw new Exception("Read DataSet: Wrong definition (TODO)");
                }
                else
                {
                    if (varName.Split('.').Length == 2)
                    {
                        if (!output.ContainsKey(varName.Split('.')[0]))
                            throw new Exception("There is no dataset bag named as \"" + varName.Split('.')[0] + "\" (TODO)");
                        if (output[varName.Split('.')[0]] is DataSetBag)
                        {
                            var bag = (DataSetBag)output[varName.Split('.')[0]];
                            bag.SetMember(varName.Split('.')[1], ParseValue(line.Replace(varDfnt + " =", "").Trim(), varType, datasetPath));
                        }
                        else
                            throw new Exception("\"" + varName.Split('.')[0] + "\" isn't a dataset bag, it is a \"" + dataTypes[varType] + "\" (TODO)");
                    }
                    else if (varName.Split('.').Length == 1)
                        output[varName.Trim()] = ParseValue(line.Replace(varDfnt + " =", "").Trim(), varType, datasetPath);
                }
            }
            return output;
        }

        public static string SerializeVariable(string name, dynamic data, string givenType = "var")
        {
            if (data is DataSetBag)
            {
                DataSetBag bag = (DataSetBag)data;
                string serializeData = $"bag {name}";
                foreach (string variableName in bag.data.Keys)
                    serializeData += $"\n {name}.{bag.data[variableName]} = {SerializeData(bag.data[variableName])}";
                return serializeData;
            }
            else if (data is string && givenType == "lnk")
                return $"lnk {name} = @\"{data}\"";
            else if (data is string && givenType == "pth")
                return $"pth {name} = @\"{data}\"";
            else if (data is string)
                return $"str {name} = \"{data}\"";
            else if (data is int)
                return $"int {name} = {data}";
            else if (data is float)
                return $"flt {name} = {data}f";
            else if (data is decimal)
                return $"dec {name} = {data}d";
            else if (data is Array)
            {
                string parseData = $"lst {name} = [";
                foreach (dynamic item in data)
                    parseData += SerializeData(item) + ", ";
                parseData = parseData.Remove(parseData.Length - 2, 2) + "]";
                return parseData;
            }
            else
                return $"var {name} = \"{(string)data}\"";
        }

        public static string SerializeData(dynamic data, bool preferLink = false)
        {
            if (data is string && preferLink)
                return $"@\"{data}\"";
            else if (data is string)
                return $"\"{data}\"";
            else if (data is int)
                return (string)data;
            else if (data is float)
                return $"{data}f";
            else if (data is decimal)
                return $"{data}d";
            else if (data is Array)
            {
                string parseData = "[";
                foreach (dynamic item in data)
                    parseData += SerializeData(item) + ", ";
                return parseData.Remove(parseData.Length - 2, 2) + "]";
            }
            else
                return (string)data;
        }

        public static void WriteDataSet(string datasetPath, Dictionary<string, dynamic> dataset)
        {
            string dataText = "[DataSet]";
            foreach (string varName in dataset.Keys)
            {
                if (varName.Split(":").Length == 2)
                {
                    dataText += "\n" + SerializeVariable(varName.Split(":")[1], dataset[varName], varName.Split(":")[0]);
                }
                else
                {
                    dataText += "\n" + SerializeVariable(varName, dataset[varName]);
                }
            }
            var file = File.Open(datasetPath, FileMode.OpenOrCreate, FileAccess.Write);
            file.Close();
            File.WriteAllText(datasetPath, dataText);
        }
    }
}