using System;
using System.Collections.Generic;
using demo.Entitys;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            TestIntersect();

            return;
            
            // 随机数生成
            // 暂不考虑复杂情况，仅生成角度一致、大小不一的长方体
            List<Cuboid> list = new List<Cuboid>();
            Cuboid c = new Cuboid();
            for (int i = 0; i < 5; i ++) {
                Cuboid c1 = new Cuboid(c.A1);
                list.Add(c1);
                c1.Pring();
            }

            Cuboid frist = list[0];
            for (int i = 1; i < list.Count; i ++) {
                frist = frist.Intersect(list[i]);
                if (frist != null) {
                    //得到交集后，继续与下一个长方体取交集。
                    continue;
                } else {
                    // 如果交集为空，不可有会存在5个都相交的情况，中断之
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

        static void TestIntersect() {
            Point p = new Point();
            p.X = 0;
            p.Y = 0;
            p.Z = 0;

            Cuboid c1 = new Cuboid(p, 2,2,2);
            Cuboid c2 = new Cuboid(p, 1,1,1);

            Cuboid result = c1.Intersect(c2);

            Console.WriteLine(result.Calc());

        }
    }
}
