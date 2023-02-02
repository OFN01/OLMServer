namespace OLMServer.Libraries
{
    public class TextProcessing
    {
        public static int GetEditDistance(string X, string Y)
        {
            int m = X.Length;
            int n = Y.Length;

            int[][] T = new int[m + 1][];
            for (int i = 0; i < m + 1; ++i)
            {
                T[i] = new int[n + 1];
            }

            for (int i = 1; i <= m; i++)
            {
                T[i][0] = i;
            }
            for (int j = 1; j <= n; j++)
            {
                T[0][j] = j;
            }

            int cost;
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    cost = X[i - 1] == Y[j - 1] ? 0 : 1;
                    T[i][j] = Math.Min(Math.Min(T[i - 1][j] + 1, T[i][j - 1] + 1),
                            T[i - 1][j - 1] + cost);
                }
            }

            return T[m][n];
        }

        public static int FindSimilarity(string x, string y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentException("Strings must not be null");
            }

            double maxLength = Math.Max(x.Length, y.Length);
            if (maxLength > 0)
            {
                // optionally ignore case if needed
                return (int)(((maxLength - GetEditDistance(x, y)) / maxLength) * 1000);
            }
            return 1000;
        }

        public static List<string> AutoComplete(string text, IEnumerable<string> completeList)
        {
            List<string> olst = new List<string>();
            List<int> similarities = new List<int>();
            foreach (string s in completeList)
            {
                foreach (string completeText in text.Split(" "))
                {
                    var brk = false;
                    foreach (string item in s.ToLower().Split(" "))
                    {
                        if (item.ToLower().Contains(completeText.ToLower()))
                        {
                            olst.Add(s);
                            similarities.Add(900 + FindSimilarity(item.ToLower(), completeText.ToLower()) / 10);
                            brk = true;
                            break;
                        }
                        else if (FindSimilarity(item.ToLower(), completeText.ToLower()) > 300)
                        {
                            olst.Add(s);
                            similarities.Add(FindSimilarity(item.ToLower(), completeText.ToLower()));
                            brk = true;
                            break;
                        }
                    }
                    if (brk)
                        break;
                }
            }

            List<string> nlst = olst.OrderBy(x => 1000 - similarities[olst.IndexOf(x)]).ToList();

            return nlst;
        }
    }
}
