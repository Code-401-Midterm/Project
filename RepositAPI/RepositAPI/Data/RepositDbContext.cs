﻿using Microsoft.EntityFrameworkCore;
using RepositAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositAPI.Data
{
    public class RepositDbContext : DbContext
    {
        public RepositDbContext(DbContextOptions<RepositDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Sets date in sql database correctly
            modelBuilder.Entity<Snippet>()
            .Property(f => f.Date)
            .HasColumnType("datetime2");

            modelBuilder.Entity<Author>().HasData(
                new Author {
                    ID = 1,
                    Name = "Jeff"
                },
                new Author
                {
                    ID = 2,
                    Name = "Kendra"
                },
                new Author {
                    ID = 3,
                    Name = "Richard"
                },
                new Author
                {
                    ID = 4,
                    Name = "Allisa"
                },     
                new Author
                {
                    ID = 5,
                    Name = "Jeremy"
                }
            );



            modelBuilder.Entity<Snippet>().HasData(
                new Snippet
                {
                    ID = 1,
                    Title = "Hello World console writeline",
                    Date = DateTime.Now,
                    CodeBody = "Console.WriteLine(\"Hello World!\")",
                    Language = Language.Csharp,
                    Notes = "This is cool.",
                    AuthorID = 1
                },
                new Snippet
                {
                    ID = 2,
                    Title = "Hello World python",
                    Date = DateTime.Now,
                    CodeBody = "Print(\"Hello World!\")",
                    Language = Language.Python,
                    Notes = "This is cooler",
                    AuthorID = 2
                },
                new Snippet
                {
                    ID = 3,
                    Title = "Node",
                    Date = DateTime.Now,
                    CodeBody = @"public class Node
                                {
                                    public object Value { get; set; }
                                    public Node Right { get; set; }
                                    public Node Left { get; set; }

                                    public Node(object value)
                                    {
                                        Value = value;
                                    }
                                }",
                    Language = Language.Csharp,
                    Notes = "Basic Node class with a value and .Next property.",
                    AuthorID = 5
                },
                new Snippet
                {
                    ID = 4,
                    Title = "Binary search",
                    Date = DateTime.Now,
                    CodeBody = @"public static int BinarySearchArray(int[] arr, int val)
                                {
                                    int start = 0;
                                    int end = arr.Length - 1;
                                    int mid;
                                    while (start <= end)
                                    {
                                        mid = (start + end) / 2;
                                        if (arr[mid] == val)
                                        {
                                            return mid;
                                        }
                                        else if (arr[mid] < val)
                                        {
                                            start = mid + 1;
                                        }
                                        else if (arr[mid] > val)
                                        {
                                            end = mid - 1;
                                        }
                                    }
                                    return -1;
                                }",
                    Language = Language.Csharp,
                    Notes = "Standard binary search on a sorted array.",
                    AuthorID = 4
                },
                new Snippet
                {
                    ID = 5,
                    Title = "Array.Prototype.Map()",
                    Date = DateTime.Now,
                    CodeBody = @"const mapTwoToThe = (input) => 
                               {
                                   return input.map(num => 2**num);
                               }",
                    Language = Language.JavaScript,
                    Notes = "Use array map method to take in an array and return a modified array. The returned array should containing the result of raising 2 to the power of the original input element.",
                    AuthorID = 3
                },
                new Snippet
                {
                    ID = 6,
                    Title = "",
                    Date = DateTime.Now,
                    CodeBody = @"def bubbleUp(arr):
                                    swapped = True
                                    while swapped == True:
                                        swapped = False
                                        i = 0
                                        for i in range(len(arr) - 1):
                                            if arr[i] > arr[i+1]:
                                                arr[i],arr[i+1] = arr[i+1],arr[i]
                                                swapped = True
                                    print arr


                                y = [4,3,1,5,-10,0]
                                bubbleUp(y)

                                def bubbleDown(arr):
                                    swapped = True
                                    while swapped == True:
                                        swapped = False
                                        i = len(arr) - 1
                                        while i > 0:
                                            if arr[i] < arr[i-1]:
                                                arr[i],arr[i-1] = arr[i-1],arr[i]
                                                swapped = True

                                            i -= 1

                                    print arr


                                x = [4,3,1,5,0,10,-4,3,9,0,-20]
                                bubbleDown(x)",
                    Language = Language.Python,
                    Notes = "Really old bubble sort in python. Does it even work?",
                    AuthorID = 1
                }
            );

        }

        public DbSet<Snippet> Snippets { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
