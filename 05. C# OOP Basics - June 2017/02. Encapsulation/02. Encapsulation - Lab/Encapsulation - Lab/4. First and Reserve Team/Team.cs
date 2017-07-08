using System;
using System.Collections.Generic;

public class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reverseTeam;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public Team(string name)
    {
        this.name = name;
        this.firstTeam = new List<Person>();
        this.reverseTeam = new List<Person>();
    }

    public IList<Person> FirstTeam
    {
        get { return this.firstTeam.AsReadOnly(); }
    }

    public void AddPlayer(Person person)
    {
        if (person.Age < 40)
        {
            this.firstTeam.Add(person);
        }
        else
        {
            this.reverseTeam.Add(person);
        }
    }

    public IList<Person> ReserveTeam
    {
        get { return this.reverseTeam.AsReadOnly(); }

    }
}