using System;

namespace Covid19Model
{
    class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumContacts { get; set; }
        public int OutbreakLevel { get; set; }

        public City(int id, string name, int numContacts)
        {
            Id = id;
            Name = name;
            NumContacts = numContacts;
            OutbreakLevel = 0;
        }

        public override string ToString()
        {
            return $"{Id} {Name} {OutbreakLevel}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // รับจำนวนเมือง
            Console.Write("Enter number of cities: ");
            int numCities = int.Parse(Console.ReadLine());

            // สร้างเมืองแต่ละเมือง
            City[] cities = new City[numCities];
            for (int i = 0; i < numCities; i++)
            {
                Console.WriteLine($"City {i}");
                Console.Write("Enter city name: ");
                string cityName = Console.ReadLine();

                int numContacts;
                do
                {
                    Console.Write("Enter number of contacts: ");
                    numContacts = int.Parse(Console.ReadLine());
                    if (numContacts >= i)
                    {
                        Console.WriteLine("Invalid ID");
                    }
                } while (numContacts >= i);

                cities[i] = new City(i, cityName, numContacts);
            }

            // แสดงผลลัพธ์เมืองทั้งหมด
            Console.WriteLine("\nCities:");
            foreach (City city in cities)
            {
                Console.WriteLine(city);
            }

            // รับเหตุการณ์และทำการปรับปรุงระดับการระบาดของเมือง
            Console.Write("\nEnter event (Outbreak, Vaccinate, or Lockdown): ");
            string eventType = Console.ReadLine();

            int cityId;
            do
            {
                Console.Write("Enter city ID: ");
                cityId = int.Parse(Console.ReadLine());
            } while (cityId >= numCities || cityId < 0);

            if (eventType == "Outbreak")
            {
                cities[cityId].OutbreakLevel++;
            }
            else if (eventType == "Vaccinate")
            {
                cities[cityId].OutbreakLevel--;
                if (cities[cityId].OutbreakLevel < 0)
                {
                    cities[cityId].OutbreakLevel = 0;
                }
            }
            else if (eventType == "Lockdown")
            {
                for (int i = 0; i < numCities; i++)
                {
                    if (cities[i].NumContacts == cityId)
                    {
                        cities[i].OutbreakLevel++;
                    }
                }
            }