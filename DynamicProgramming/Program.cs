using System;

namespace DynamicProgramming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //  Make sum with given coin . 
            // Using Dynamic programming - O(m.n)
            int n = 18;
            int[] a= new int[] { 1, 5, 7 };
            int[] dp = new int[n+1];
            Array.Fill(dp, -1);   
            Console.WriteLine("Minimum coin required to  make {0} is : {1}",n,minCoins(n,a,dp));
            Console.WriteLine();
            foreach (int i in dp) { Console.Write(i + " "); }
        }

        static int minCoins(int n, int[] a, int[] dp) 
        {
            if (n == 0) return 0;
            
            int ans = int.MaxValue;

            for (int i = 0; i < a.Length; i++) 
            {
                if (n - a[i] >= 0) 
                {
                    int subAns = 0;
                    if (dp[n - a[i]] != -1) 
                    { 
                        subAns = dp[n - a[i]];
                    }

                    else {
                        subAns = minCoins(n - a[i], a, dp); 
                    }
                    
                    if (subAns != int.MaxValue && subAns + 1 < ans) {
                        ans = subAns + 1; 
                    }
                }
            }
            
            return dp[n] =ans;
        }
    }
}
