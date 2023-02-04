using System;
using System.IO;
using System.Collections.Generic;
using System.Dynamic;

namespace AdvancedDatasetManager
{
    public class DataSet : DynamicObject
    {
        public string path;
        public Dictionary<string, dynamic> data { get; private set; } = new Dictionary<string, dynamic>();
        bool isLoaded = false;

        public DataSet(string datasetPath)
        {
            if (datasetPath == "")
            {
                return;
            }
            path = datasetPath;
        }

        public DataSet(string datasetPath, Dictionary<string, dynamic> data)
        {
            this.data = data;
        }

        public void SaveData()
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new Exception("No path selected!");
            DataSetManager.WriteDataSet(path, data);
        }

        public void SaveData(string path)
        {
            DataSetManager.WriteDataSet(path, data);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (!isLoaded)
            {
                data = DataSetManager.ReadDataSet(path);
                isLoaded = true;
            }

            result = null;

            if (!data.ContainsKey(binder.Name))
                return false;

            result = data[binder.Name];
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (!isLoaded)
            {
                data = DataSetManager.ReadDataSet(path);
                isLoaded = true;
            }

            if (!data.ContainsKey(binder.Name))
                data.Add(binder.Name, value);
            data[binder.Name] = value;

            return true;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            if (!isLoaded)
            {
                data = DataSetManager.ReadDataSet(path);
                isLoaded = true;
            }

            Delegate del = (Delegate)data[binder.Name];
            result = del.DynamicInvoke(args);

            return true;
        }

        public bool TryGetMember(string name, out object result)
        {
            if (!isLoaded)
            {
                data = DataSetManager.ReadDataSet(path);
                isLoaded = true;
            }

            result = null;

            if (!data.ContainsKey(name))
                return false;

            result = data[name];
            return true;
        }

        public bool TrySetMember(string name, object value)
        {
            if (!isLoaded)
            {
                data = DataSetManager.ReadDataSet(path);
                isLoaded = true;
            }

            if (!data.ContainsKey(name))
                data.Add(name, value);
            data[name] = value;

            return true;
        }
    }
}
