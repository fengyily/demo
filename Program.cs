using System;
using System.Collections.Generic;
using demo.Entitys;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // 随机数生成
            // 暂不考虑复杂情况，仅生成角度一致、大小不一的长方体
            
            List<Cuboid> list = new List<Cuboid>();
            Cuboid c = new Cuboid();
            for (int i = 0; i < 2; i ++) {
                Cuboid c1 = new Cuboid(c.A1);
                list.Add(c1);
                c1.Pring();
            }

            Cuboid frist = list[0];
            for (int i = 1; i < list.Count; i ++) {
                frist = frist.Intersect(list[i]);
                if (frist != null) {
                    continue;
                } else {
                    break;
                }
            }
            if (frist != null) {
                Console.WriteLine("result = {0}", frist.Calc());
            }
            else {
                Console.WriteLine("result = 0");
            }
            
            Console.WriteLine("Hello World!");
        }
    }
}
