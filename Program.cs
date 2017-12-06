using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cours
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>(); 
            using (StreamReader sr = new StreamReader("animal.txt")) 
            {
                string line;
                while ((line = sr.ReadLine()) != null) 
                {
                    try{
                        string[] lines = Regex.Split(line, ",");
                        
                        int id = int.Parse(lines[0]);
                        string nom = lines[1].Trim();
                        decimal poids = Convert.ToDecimal(lines[2]);
                        string[] an = Regex.Split(lines[3], "/");
                        DateTime annee = new DateTime(int.Parse(an[2]), int.Parse(an[1]), int.Parse(an[0]));
                        string couleur = lines[4].Trim();
                        int pattes = int.Parse(lines[5]);
                        bool carnivore =  Convert.ToBoolean(lines[6]);
                        
                        animals.Add(new Animal(id, nom, poids, annee, couleur, pattes, carnivore));
                    } catch(Exception e){
                        Console.WriteLine(e);
                    }
                }

                IComparerAnimal sorter = new IComparerAnimal();
                animals.Sort((Animal x, Animal y) => sorter.CompareNom(x, y));
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"SortedByName.txt"))
                {
                    foreach(Animal animal in animals) 
                    {
                        file.WriteLine(animal.ToString());
                    }
                }
                
                animals.Sort((Animal x, Animal y) => sorter.ComparePoids(x, y));
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"SortedByWeight.txt"))
                {
                    foreach(Animal animal in animals) 
                    {
                        file.WriteLine(animal.ToString());
                    }
                }

                animals.Sort((Animal x, Animal y) => sorter.CompareCouleur(x, y));
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"SortedByColor.txt"))
                {
                    foreach(Animal animal in animals) 
                    {
                        file.WriteLine(animal.ToString());
                    }
                }
                                
                animals.Sort((Animal x, Animal y) => sorter.Compare(x, y));
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"SortedById.txt"))
                {
                    foreach(Animal animal in animals) 
                    {
                        file.WriteLine(animal.ToString());
                    }
                }
            }
        }
    }
}
