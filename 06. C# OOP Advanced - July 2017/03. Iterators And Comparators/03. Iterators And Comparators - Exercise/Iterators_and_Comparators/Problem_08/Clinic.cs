using System;
using System.Collections.Generic;
using System.Linq;

public class Clinic
{
    private readonly List<Pet> pets;

    private readonly Pet[] rooms;

    private int roomsCount;

    public Clinic(string name, int rooms)
    {
        this.rooms = new Pet[rooms];
        this.RoomsCount = rooms;
        this.Name = name;
    }

    public string Name { get; private set; }

    public int RoomsCount
    {
        get => this.roomsCount;
        private set
        {
            if (value % 2 == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            this.roomsCount = value;
        }
    }

    public bool AddPet(Pet pet)
    {
        if (this.rooms.Contains(null))
        {
            if (this.rooms.All(p => p == null))
            {
                this.rooms[this.RoomsCount / 2] = pet;
            }
            else if (this.rooms.All(p => p != null))
            {
                return false;
            }
            else
            {
                int busyRooms = this.rooms.Count(p => p != null);
                if (busyRooms % 2 != 0)
                {
                    for (int i = this.RoomsCount / 2; i >= 0; i--)
                    {
                        if (this.rooms[i] == null)
                        {
                            this.rooms[i] = pet;
                            return true;
                        }
                    }
                }
                else
                {
                    for (int i = this.RoomsCount / 2; i < this.rooms.Length; i++)
                    {
                        if (this.rooms[i] == null)
                        {
                            this.rooms[i] = pet;
                            return true;
                        }
                    }
                }
            }

            return true;
        }
        return false;
    }

    public bool ReleasePet()
    {
        int index = this.RoomsCount / 2;
        int count = 0;

        while (true)
        {
            if (index == this.rooms.Length - 1)
            {
                if (this.rooms[index] != null)
                {
                    this.rooms[index] = null;
                    return true;
                }
                index = 0;
                count++;
            }

            if (count == 1 && index == this.RoomsCount / 2)
            {
                return false;
            }

            if (this.rooms[index] != null)
            {
                this.rooms[index] = null;
                return true;
            }

            index++;
        }
    }

    public bool HasEmptyRooms()
    {
        return this.rooms.Contains(null);
    }

    public void PrintRoom(int index)
    {
        string result = "Room empty";
        if (this.rooms[index - 1] != null)
        {
            result = this.rooms[index - 1].ToString();
        }

        Console.WriteLine(result);
    }

    public void PrintAllInClinic()
    {
        foreach (Pet pet in this.rooms)
        {
            string result = "Room empty";
            if (pet != null)
            {
                result = pet.ToString();
            }

            Console.WriteLine(result);
        }
    }
}