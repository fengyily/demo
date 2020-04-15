using System;
using System.Collections.Generic;
using demo.Entitys;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "test")
            {
                // 测试两个长方体相交方法
                TestIntersect();
                return;
            } 
            else {
                // 随机数生成
                // 暂不考虑复杂情况，仅生成角度一致、大小不一的长方体
                List<Cuboid> list = new List<Cuboid>();
                Cuboid c = new Cuboid();
                for (int i = 0; i < 5; i ++) {
                    Cuboid c1 = new Cuboid(c.A1);
                    list.Add(c1);
                    c1.Pring();
                }

                // 从第一个开始，与后面的长方体取交集，再继续
                // 如最终交集存在，说明该交集就是所有长方体的交集
                Cuboid frist = list[0];
                for (int i = 1; i < list.Count; i ++) {
                    frist = frist.Intersect(list[i]);
                    if (frist != null) {
                        //得到交集后，继续与下一个长方体取交集。
                        Console.WriteLine(frist.Calc());
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
            }
        }

        static void TestIntersect() {
            // 假设两个长方体起点相同
            Point p = new Point();
            p.X = 0;
            p.Y = 0;
            p.Z = 0;

            Console.WriteLine("验证高度");
            // 初使化两个长方体，验证高度
            Cuboid c1 = new Cuboid(p, 2,2,5);
            Cuboid c2 = new Cuboid(p, 1,1,4);

            // 验证结果
            Cuboid result = c1.Intersect(c2);

            Console.WriteLine(result.Calc());

            Console.WriteLine("验证宽度");
            // 初使化两个长方体，验证宽度
            c1 = new Cuboid(p, 2,5,2);
            c2 = new Cuboid(p, 1,3,1);

            // 验证结果
            result = c1.Intersect(c2);

            Console.WriteLine(result.Calc());

            Console.WriteLine("验证长度");
            // 初使化两个长方体，验证长度
            c1 = new Cuboid(p, 5,2,2);
            c2 = new Cuboid(p, 2,1,1);

            // 验证结果
            result = c1.Intersect(c2);

            Console.WriteLine(result.Calc());
        }
    }
}
