using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cours
{
    public class Animal 
    { 
        protected int idAnimal;
        protected string nom;
        protected decimal poids;
        protected DateTime dateNaissance;
        protected string couleur;
        protected int nombrePattes;
        protected bool estCarnivore;

        public bool EstCarnivore
        {
            get { return estCarnivore; }
            set
            {
                estCarnivore = value;
            }
        }

        public decimal Poids
        {
            get { return poids; }
            set
            {
                poids = value;
            }
        }

        public DateTime DateNaissance
        {
            get { return dateNaissance; }
            set
            {
                dateNaissance = value;
            }
        }

        public string Couleur
        {
            get { return couleur; }
            set
            {
                couleur = value;
            }
        }

        public string Nom
        {
            get { return nom; }
            set
            {
                nom = value;
            }
        }

        public int IdAnimal
        {
            get { return idAnimal; }
            set
            {
                idAnimal = value;
            }
        }

        public int NombrePattes
        {
            get { return nombrePattes; }
            set
            {
                nombrePattes = value;
            }
        }

        public void marcher()
        {
            Console.WriteLine("L'animal  " + this.nom + " marche avec " + this.nombrePattes + "pattes !");
        }

        public void description() 
        {
            string manger;
            if(!this.estCarnivore) {
                manger = "n'est pas carnivore.";
            } else {
                manger = "est carnivore.";
            }
            Console.WriteLine("nom de l'animal " + this.nom + " est né le " + this.dateNaissance + ", il pèse "
            + this.poids +", il est de couleur " + this.couleur + ", il a " + this.nombrePattes + " pattes, il " + manger );
        }

        public Animal(int idAnimal, string nom, decimal poids, DateTime dateNaissance, string couleur, int nombrePattes, bool estCarnivore)
        {
            this.idAnimal = idAnimal;
            this.nom = nom;
            this.poids = poids;
            this.dateNaissance = dateNaissance;
            this.couleur = couleur;
            this.nombrePattes = nombrePattes;
            this.estCarnivore = estCarnivore;
        }

        public override bool Equals(object obj)
        {
            bool isEqual = false;
            if (obj.GetType() == typeof(Animal)) 
            {
            Animal animal = obj as Animal; 
                if (animal == null) 
                isEqual = false;
                else
                isEqual = idAnimal == animal.GetHashCode(); 
            }
            return isEqual;
        }

        public override int GetHashCode()
        {
            return this.idAnimal; 
        }

        public override string  ToString()
        {
            return this.idAnimal+","+this.nom+","+this.poids+","+this.dateNaissance.ToString("d")+","+this.couleur+","+this.nombrePattes+","+this.estCarnivore;
        }
    }

    public class IComparerAnimal : IComparer<Animal>
    {
        public int Compare(Animal x, Animal y)
        {
            if (x.IdAnimal.CompareTo(y.IdAnimal) != 0)
            {
                return x.IdAnimal.CompareTo(y.IdAnimal);
            }
            else
            {
                return 0;
            }
        }

        public int ComparePoids(Animal x, Animal y)
        {
            if (x.Poids.CompareTo(y.Poids) != 0)
            {
                return x.Poids.CompareTo(y.Poids);
            }
            else
            {
                return 0;
            }
        }

        public int CompareNom(Animal x, Animal y)
        {
            if (x.Nom.CompareTo(y.Nom) != 0)
            {
                return x.Nom.CompareTo(y.Nom);
            }
            else
            {
                return 0;
            }
        }
        public int CompareCouleur(Animal x, Animal y)
        {
            if (x.Couleur.CompareTo(y.Couleur) != 0)
            {
                return x.Couleur.CompareTo(y.Couleur);
            }
            else
            {
                return 0;
            }
        }
    }
}
