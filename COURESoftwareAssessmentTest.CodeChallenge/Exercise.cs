using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COURESoftwareAssessmentTest.CodeChallenge
{
    public class Exercise
    {

        public int Question1(int[] arr)
        {
            int point = 0;
            foreach (int i in arr) 
            { 
                if(i == 8)
                {
                    point += 5;
                }

                if(i %  2 == 0)
                {
                    point += 1;
                }
                else
                {
                    point += 3;
                }
            }
            return point;
        }
    }
}
