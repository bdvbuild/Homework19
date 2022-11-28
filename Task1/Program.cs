using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Модель  компьютера  характеризуется  кодом  и  названием  марки компьютера,  типом  процессора,  частотой  работы  процессора,
//объемом оперативной памяти, объемом жесткого диска, объемом памяти видеокарты, стоимостью компьютера в условных единицах и количеством экземпляров,
//имеющихся в наличии. Создать список, содержащий 6-10 записей с различным набором значений характеристик.


namespace Task1
{
    class Computer
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string CPU { get; set; }
        public double CPUFrequency { get; set; }
        public int RAM { get; set; }
        public int HDD { get; set; }
        public int GPU { get; set; }
        public int Price { get; set; }
        public int NumInStock { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Computer> computers = new List<Computer>()
            {
                new Computer(){Code=5028542, Name="DEXP Aquilon O271", CPU="Intel", CPUFrequency=1.1, RAM=4, HDD=120, GPU=0, Price=10299, NumInStock=30},
                new Computer(){Code=5056469, Name="DEXP Atlas H370", CPU="Intel", CPUFrequency=2.9, RAM=16, HDD=240, GPU=0, Price=32299, NumInStock=18},
                new Computer(){Code=5052571, Name="ZET Gaming NEO M050", CPU="Intel", CPUFrequency=3.7, RAM=16, HDD=512, GPU=4, Price=49999, NumInStock=9},
                new Computer(){Code=4894755, Name="MSI MAG Infinite S3", CPU="Intel", CPUFrequency=2.6, RAM=16, HDD=512, GPU=6, Price=76299, NumInStock=66},
                new Computer(){Code=4874295, Name="HP Pavilion Gaming TG01", CPU="AMD", CPUFrequency=4, RAM=16, HDD=512, GPU=4, Price=49999, NumInStock=23},
                new Computer(){Code=1690700, Name="Lenovo IdeaCentre Gaming G5", CPU="Intel", CPUFrequency=3.6, RAM=8, HDD=512, GPU=4, Price=45999, NumInStock=5},
                new Computer(){Code=4873023, Name="Acer Revo Box RN96", CPU="Intel", CPUFrequency=3, RAM=4, HDD=256, GPU=0, Price=27499, NumInStock=2},
                new Computer(){Code=4894746, Name="MSI MAG Infinite S3", CPU="Intel", CPUFrequency=2.6, RAM=16, HDD=512, GPU=12, Price=89999, NumInStock=6},
            };

            ////все компьютеры с указанным процессором.Название процессора запросить у пользователя;
            Console.Write("Введите название процессора: ");
            string cpu = Console.ReadLine();
            List<Computer> computers1 = computers.Where(x => x.CPU == cpu).ToList();
            Print(computers1);

            ////все компьютеры с объемом ОЗУ не ниже, чем указано. Объем ОЗУ запросить у пользователя;
            Console.Write("Введите объем ОЗУ: ");
            int ram = Convert.ToInt32(Console.ReadLine());
            List<Computer> computers2 = computers.Where(x => x.RAM >= ram).OrderBy(x => x.RAM).ToList();
            Print(computers2);

            //вывести весь список, отсортированный по увеличению стоимости;
            List<Computer> computers3 = computers.OrderBy(x => x.Price).ToList();
            Print(computers3);

            //вывести весь список, сгруппированный по типу процессора;
            IEnumerable<IGrouping<string, Computer>> computers4 = computers.GroupBy(x => x.CPU);
            foreach (IGrouping<string, Computer> cm in computers4)
            {
                Console.WriteLine(cm.Key);
                foreach (Computer c in cm)
                {
                    Console.WriteLine($"{c.Code} / {c.Name} / CPU = {c.CPU} / {c.CPUFrequency} / RAM = {c.RAM} / HDD = {c.HDD} / GPU = {c.GPU} / Price = {c.Price} / In stock = {c.NumInStock}");
                }
            }

            //найти самый дорогой и самый бюджетный компьютер;
            Computer computerMax = computers.OrderByDescending(x => x.Price).FirstOrDefault();
            Console.WriteLine($"Самый дорогой: {computerMax.Code} / {computerMax.Name} / Price = {computerMax.Price}");
            Computer computerMin = computers.OrderBy(x => x.Price).FirstOrDefault();
            Console.WriteLine($"Самый дешевый: {computerMin.Code} / {computerMin.Name} / Price = {computerMin.Price}");

            //есть ли хотя бы один компьютер в количестве не менее 30 штук?
            Console.WriteLine(computers.Any(x => x.NumInStock >= 30));

            Console.ReadLine();
        }
        static void Print(List<Computer> computers)
        {
            foreach (Computer c in computers)
            {
                Console.WriteLine($"{c.Code} / {c.Name} / CPU = {c.CPU} / {c.CPUFrequency} / RAM = {c.RAM} / HDD = {c.HDD} / GPU = {c.GPU} / Price = {c.Price} / In stock = {c.NumInStock}");
            }
        }
    }
}
