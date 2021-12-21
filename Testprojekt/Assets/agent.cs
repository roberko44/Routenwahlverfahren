using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class agent : MonoBehaviour
{
    public Rigidbody2D r2d;
    ArrayList persons = new ArrayList();
    public float speed = 2f;

    public GameObject agentPrefab;

    Dictionary<int, Person> personss = new Dictionary<int, Person>();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello, Rober.");
        readTextFile("bottleneck_traj.txt");
        //transform.position = (Vector3)positions[0];
        foreach(KeyValuePair<int, Person> entry in personss)
        {
            Vector3 pos = new Vector3(entry.Value.steps[0].xPos, entry.Value.steps[0].yPos, entry.Value.steps[0].zPos);
            GameObject agent = Instantiate(agentPrefab, pos, Quaternion.identity);
            agent.name = "" + entry.Value.id;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        foreach (KeyValuePair<int, Person> entry in personss)
        {
            int index = entry.Value.index;
            int oldIndex = entry.Value.oldIndex;
            if (oldIndex != index)
        {
            GameObject agent = GameObject.Find("" + entry.Value.id);
                if (index < entry.Value.steps.Count)
                {
                    Vector3 vec3 = new Vector3(entry.Value.steps[index].xPos, entry.Value.steps[index].yPos, entry.Value.steps[index].zPos);
                    agent.transform.position = Vector3.MoveTowards(agent.transform.position, vec3, Time.deltaTime * speed);
                    agent.GetComponent<SpriteRenderer>().color = new Color((float)entry.Value.steps[index].color / 255.0f, (float)entry.Value.steps[index].color / 255.0f, (float)entry.Value.steps[index].color / 255.0f, 1f);
                }
            }
        }

        foreach (KeyValuePair<int, Person> entry in personss)
            {
                int index = entry.Value.index;
                int oldIndex = entry.Value.oldIndex;
                GameObject agent = GameObject.Find("" + entry.Value.id);
                if (index < entry.Value.steps.Count)
                {
                    if (agent.transform.position == new Vector3(entry.Value.steps[index].xPos, entry.Value.steps[index].yPos, entry.Value.steps[index].zPos))
                {
                    entry.Value.oldIndex = index;
                    entry.Value.index++;
                }
                }

            }

        
        /*transform.position = Vector3.MoveTowards(transform.position, (Vector3)persons[index], Time.deltaTime*speed);
        if (transform.position == (Vector3)persons[index])
        {
            index++;
            Debug.Log("Index: " +index);
        }*/
    }

    void readTextFile(string file_path)
    {   
        StreamReader inp_stm = new StreamReader(file_path);

        while (!inp_stm.EndOfStream)
        {
            string inp_ln = inp_stm.ReadLine();

            if (inp_ln.Length != 0)
            {
                if (inp_ln[0] != '#')
                {
                    //Debug.Log(inp_ln);
                    inp_ln = inp_ln.Replace(".", ",");
                    string[] content = inp_ln.Split("\t");
                    // persons.Add(new Person(int.Parse(content[0]), int.Parse(content[1]), float.Parse(content[2]), float.Parse(content[3]), float.Parse(content[4]), float.Parse(content[5]), float.Parse(content[6]), float.Parse(content[7]), float.Parse(content[8])));
                    if (!personss.ContainsKey(int.Parse(content[0])))
                    {
                        personss[int.Parse(content[0])] = new Person(int.Parse(content[0]), float.Parse(content[5]), float.Parse(content[6]));
                    }
                    Person.DynamicValue dv = new Person.DynamicValue(float.Parse(content[2]), float.Parse(content[3]), float.Parse(content[4]), float.Parse(content[7]), int.Parse(content[8]));
                    personss[int.Parse(content[0])].steps.Add(int.Parse(content[1]), dv);
                }
            }
            // Do Something with the input. 
           
        }

        
        Debug.Log(personss);

        inp_stm.Close();
    }

}
