using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    private static List<Pet> pets = new List<Pet>();
    private static Dictionary<string, Clinic> clinics = new Dictionary<string, Clinic>();
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine().Split();

            string command = tokens[0];

            switch (command)
            {
                case "Create":
                    try
                    {
                        string type = tokens[1];

                        if (type == "Pet")
                        {
                            pets.Add(new Pet(tokens[2], int.Parse(tokens[3]), tokens[4]));
                        }
                        else if (type == "Clinic")
                        {
                            clinics.Add(tokens[2], new Clinic(tokens[2], int.Parse(tokens[3])));
                        }
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                    break;
                case "Add":
                    try
                    {
                        Console.WriteLine(AddPetToClinic(tokens[1], tokens[2]));
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                    break;
                case "Release":
                    Console.WriteLine(ReleasePetFromClinic(tokens[1]));
                    break;
                case "HasEmptyRooms":
                    Console.WriteLine(HasEmptyRooms(tokens[1]));
                    break;
                case "Print":
                    if (tokens.Length == 2)
                    {
                        clinics[tokens[1]].PrintAllInClinic();
                    }
                    else
                    {
                        clinics[tokens[1]].PrintRoom(int.Parse(tokens[2]));
                    }
                    break;
            }
        }
    }

    private static bool HasEmptyRooms(string clinicName)
    {
        if (clinics.ContainsKey(clinicName))
        {
            return clinics[clinicName].HasEmptyRooms();
        }

        throw new InvalidOperationException("Invalid Operation!");
    }

    private static bool ReleasePetFromClinic(string clinicName)
    {
        if (clinics.ContainsKey(clinicName))
        {
            return clinics[clinicName].ReleasePet();
        }

        return false;
    }

    private static bool AddPetToClinic(string petName, string clinicName)
    {
        var pet = pets.FirstOrDefault(p => p.Name == petName);
        if (pet != null)
        {
            if (clinics.ContainsKey(clinicName))
            {
                return clinics[clinicName].AddPet(pet);
            }
        }

        throw new InvalidOperationException("Invalid Operation!");
    }
}