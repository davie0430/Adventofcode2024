using static System.Formats.Asn1.AsnWriter;

namespace day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("day1.txt");
            List<int> left = new List<int>();
            List<int> right = new List<int>();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] pairs = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                
                left.Add(int.Parse(pairs[0]));
                right.Add(int.Parse(pairs[1]));
            }
            sr.Close();

            //first task:

            left.Sort(); right.Sort();
            int finalNum = 0;
            for (int i = 0; i < left.Count; i++)
            {
                int distance = Math.Abs(left[i] - right[i]);
                finalNum += distance;
            }
            Console.WriteLine($"Distance between lists: {finalNum}");

            //second task:

            int similarityScore = 0;
            int count = 0;
            for (int i = 0; i < left.Count; i++)
            {
                for (int j = 0; j < right.Count; j++)
                {
                    if (left[i] == right[j]) { count++; }
                }
                similarityScore += count * left[i];
                count = 0;
            }
            Console.WriteLine($"Similarity score: {similarityScore}");
        }
    }
}
