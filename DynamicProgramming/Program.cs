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

            /*
             * Removee this comment for minCoin function 
            int n = 18;
            int[] a= new int[] { 1, 5, 7 };
            int[] dp = new int[n+1];
            Array.Fill(dp, -1);   
            Console.WriteLine("Minimum coin required to  make {0} is : {1}",n,minCoins(n,a,dp));
            Console.WriteLine();
            foreach (int i in dp) { Console.Write(i + " "); }
          */
            /*
                        int w = 10;
                        int n = 4;
                        int[] val = { 10, 40, 30, 50 };
                        int[] wt = { 5, 4, 6, 3 };

                        int[,] mat = new int[n + 1,w+1];
                        for (int i = 0; i < n; i++) {
                            for (int j= 0; j < w; j++) 
                            {
                                mat[i, j] = -1;
                            }
                        }

                        for (int i = 0; i < n; i++)
                        {
                            for (int j = 0; j < w; j++)
                            {
                                Console.Write("{0}  ", mat[i, j]);
                            }
                        }*/

            // Longest common sub sequence 
            String a = "ABCAB", b = "AECB";
          Console.WriteLine("LCA :  " + Lca(a.Length, b.Length, a, b));


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

        static int Lca(int m, int n, string a, string b) 
        {
            int[,] dp = new int[m + 1, n + 1];
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    Console.Write("{0}  ", dp[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();

            return LcaUtil(m,n,a,b,dp);
        }

        static int LcaUtil(int m, int n, string a, string b, int[,] dp) 
        {
            for (int i = 1; i <= m; i++) 
            {
                for (int j = 1; j <= n; j++) 
                {
                    if (a[i - 1] == b[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else 
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i , j-1]);
                    }
                }

            }
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    Console.Write("{0}  ", dp[i, j]);
                }
                Console.WriteLine();
            }




                    return dp[m, n];
        }

    }
}
