using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string instructionInput;
            int numBooks;
            int instructionNumber;
            string[] seperatedInstructions;
            double tempPrice;
            string tempTitle, tempAuthor, tempISBN;
            while(true)
            {
                Console.Write("Enter number of books and instruction number (1 or 2)\nin the format \"books instruction\":");
                instructionInput = Console.ReadLine();
                seperatedInstructions = instructionInput.Split(' ');
                Int32.TryParse(seperatedInstructions[0], out numBooks);
                Int32.TryParse(seperatedInstructions[1], out instructionNumber);
                    Book[] books = new Book[numBooks];
                    for(int i=0;i<numBooks;i++)
                    {
                        Console.Write("Book " + (i + 1) + " Title:");
                        tempTitle = Console.ReadLine();
                        Console.Write("Book " + (i + 1) + " Author:");
                        tempAuthor = Console.ReadLine();
                        Console.Write("Book " + (i + 1) + " Price:");
                        Double.TryParse(Console.ReadLine(),out tempPrice);
                        Console.Write("Book " + (i + 1) + " ISBN:");
                        tempISBN = Console.ReadLine();
                        books[i] = new Book(tempTitle, tempAuthor, tempPrice, tempISBN);
                    }
                if (instructionNumber == 1)
                {
                    sortByPrice(numBooks, ref books);
                    for (int i = 0; i < numBooks; i++)
                    {
                        Console.WriteLine(books[i].PrintInformation());
                    }
                }
                else if (instructionNumber == 2)
                {
                    sortByTitle(numBooks, ref books);
                    for (int i = 0; i < numBooks; i++)
                    {
                        Console.WriteLine(books[i].PrintInformation());
                    }
                }
            }
            void sortByPrice(int arrayLength, ref Book[] arrayToSort)
            {
                bool flag = true;
                Book tempholder;
                for (int i = 0; i < arrayLength && flag; i++)
                {
                    flag = false;
                    for (int j = 0; j < arrayLength - 1; j++)
                    {
                        if (arrayToSort[j + 1].Price < arrayToSort[j].Price)
                        {
                            tempholder = arrayToSort[j];
                            arrayToSort[j] = arrayToSort[j + 1];
                            arrayToSort[j + 1] = tempholder;
                            flag = true;
                        }
                    }
                }
            }
            void sortByTitle(int arrayLength, ref Book[] arrayToSort)
            {
                bool flag = true;
                Book tempholder;
                for (int i = 0; i < arrayLength && flag; i++)
                {
                    flag = false;
                    for (int j = 0; j < arrayLength - 1; j++)
                    {
                        if (arrayToSort[j].Title.CompareTo(arrayToSort[j+1].Title)==1)
                        {
                            tempholder = arrayToSort[j];
                            arrayToSort[j] = arrayToSort[j + 1];
                            arrayToSort[j + 1] = tempholder;
                            flag = true;
                        }
                    }
                }
            }
        }
    }
    class Book
    {
        private string title;
        private string author;
        private double price;
        private string isbn;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public string ISBN
        {
            get { return isbn; }
            set { isbn = value; }
        }
        public Book(string title, string author, double price, string isbn)
        {
            this.title = title;
            this.author = author;
            this.price = price;
            this.isbn = isbn;
        }
        public string PrintInformation()
        {
            return title + " written by " + author + " is " + price + " with ISBN " + isbn;
        }
    }
}
