using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace PiAA_3
{
    class Program
    {
        static bool possible(long val,int k,int[] arr)
        {
            int segmentCover = 1;
            int iLastCover = 0;
            int lastPoint = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] - lastPoint <= val)
                {
                    iLastCover = i;
                }
                else
                {
                    if (i == 1) return false;
                    segmentCover++;
                    if (i + 1 <= arr.Length - 1)
                    {
                        if (arr[i + 1] - arr[i] <= val)
                        {
                            lastPoint = arr[i];
                            iLastCover = i + 1;
                        }
                        continue;
                    }
                    if (arr[i] - arr[iLastCover] <= val)
                    {
                        lastPoint = arr[iLastCover];
                        iLastCover = i;
                        continue;
                    }
                }
                
            }

            return segmentCover <= k;

        }
        static long binSearchAnswer(int[] arr, int k)
        {
            long left = 0, right = arr[arr.Length-1] - arr[0];
            while (right - left > 1)
            {
                long mid = (left + right) / 2;
                
                if (possible(mid, k,arr))
                {
                    
                    right = mid;
                }
                else
                {
                    
                    left = mid;
                }
            }
            
            return right;
        }
        static void Main(string[] args)
        {
            string inFile = args[0];
            FileStream inFileStream = new FileStream("./"+inFile, FileMode.Open, FileAccess.Read);
            FileStream outFileStream = new FileStream("./programm.out", FileMode.Open, FileAccess.Write);
            outFileStream.SetLength(0);
            StreamReader reader = new StreamReader(inFileStream);
            StreamWriter writer = new StreamWriter(outFileStream);
            int N = int.Parse(reader.ReadLine());
            int K = int.Parse(reader.ReadLine());
            int[] nums = new int[N];
            for (int i = 0; i < N; i++)
            {
                nums[i] = int.Parse(reader.ReadLine());
            }

            long answer = binSearchAnswer(nums, K);
            Console.Write(answer);
            writer.Write(answer);
            reader.Close();
            writer.Close();
            Console.ReadKey();
        }
    }
}
