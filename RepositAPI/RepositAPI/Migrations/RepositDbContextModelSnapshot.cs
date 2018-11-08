﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositAPI.Data;

namespace RepositAPI.Migrations
{
    [DbContext(typeof(RepositDbContext))]
    partial class RepositDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RepositAPI.Models.Author", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Authors");

                    b.HasData(
                        new { ID = 1, Name = "Jeff" },
                        new { ID = 2, Name = "Kendra" },
                        new { ID = 3, Name = "Richard" },
                        new { ID = 4, Name = "Allisa" },
                        new { ID = 5, Name = "Jeremy" }
                    );
                });

            modelBuilder.Entity("RepositAPI.Models.Snippet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorID");

                    b.Property<string>("CodeBody")
                        .IsRequired();

                    b.Property<int>("Language");

                    b.Property<string>("Notes");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.ToTable("Snippets");

                    b.HasData(
                        new { ID = 1, AuthorID = 1, CodeBody = @"
Console.WriteLine(""Hello World!"")", Language = 8, Notes = "This is cool.", Title = "Hello World console writeline" },
                        new { ID = 2, AuthorID = 2, CodeBody = @"
Print(""Hello World!"")", Language = 4, Notes = "This is cooler", Title = "Hello World python" },
                        new { ID = 3, AuthorID = 5, CodeBody = @"
public class Node
{
    public object Value { get; set; }
    public Node Right { get; set; }
    public Node Left { get; set; }

    public Node(object value)
    {
        Value = value;
    }
}", Language = 8, Notes = "Basic Node class with a value and .Next property.", Title = "Node" },
                        new { ID = 4, AuthorID = 4, CodeBody = @"
public static int BinarySearchArray(int[] arr, int val)
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
}", Language = 8, Notes = "Standard binary search on a sorted array.", Title = "Binary search" },
                        new { ID = 5, AuthorID = 3, CodeBody = @"
const mapTwoToThe = (input) => 
{
    return input.map(num => 2**num);
}", Language = 0, Notes = "Use array map method to take in an array and return a modified array. The returned array should containing the result of raising 2 to the power of the original input element.", Title = ".Map()" },
                        new { ID = 6, AuthorID = 1, CodeBody = @"
def bubbleUp(arr):
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
bubbleDown(x)", Language = 4, Notes = "Really old bubble sort in python. Does it even work?", Title = "Bubblesort" },
                        new { ID = 7, AuthorID = 2, CodeBody = @"
public int numUniqueEmails(String[] emails) 
{
    Set<String> seen = new HashSet();
    for (String email: emails)
    {
        int i = email.indexOf('@');
        String local = email.substring(0, i);
        String rest = email.substring(i);
        if (local.contains(""+""))
        {
            local = local.substring(0, local.indexOf('+'));
        }
        local = local.replaceAll(""."", "");
        seen.add(local + rest);
    }

    return seen.size();
}", Language = 2, Notes = "Email algorithm using java", Title = "Finding unique emails given email rules" },
                        new { ID = 8, AuthorID = 5, CodeBody = @"
<form>
    First name:< br >
    < input type = ""text"" name = ""firstname"" value = ""Mickey"" >
    < br >
    Last name:< br >
    < input type = ""text"" name = ""lastname"" value = ""Mouse"" >
    < br >< br >
    < input type = ""submit"" value = ""Submit"" >
</ form > ", Language = 9, Notes = "Simple HTML form from w3schools", Title = "Html form" },
                        new { ID = 9, AuthorID = 1, CodeBody = @"
const newPatient = (req, res) => {
    let SQL = 'INSERT INTO patients (first_name, last_name) VALUES ($1,$2) ON CONFLICT DO NOTHING RETURNING id';
    let values = [req.body.first_name, req.body.last_name];
    client.query(SQL, values, (err, serverRes) => {
        if(err){
            console.log(values);
            console.error(err);
            res.render('pages/error', {message: err});
        }else{
            res.redirect(`/patient/${serverRes.rows[0].id}?added=true`);
        }
    });
};", Language = 0, Notes = "Using sql with javascript. sample call", Title = "Superagent" },
                        new { ID = 10, AuthorID = 3, CodeBody = @"
SELECT * FROM myTable", Language = 11, Notes = "Simple sql query. * means everything!", Title = "SQL" }
                    );
                });

            modelBuilder.Entity("RepositAPI.Models.Snippet", b =>
                {
                    b.HasOne("RepositAPI.Models.Author", "Author")
                        .WithMany("Snippets")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
