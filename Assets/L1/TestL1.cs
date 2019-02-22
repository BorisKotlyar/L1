using Lesson1.Model;
using UnityEngine;

namespace Lesson1
{
    public class TestL1 : MonoBehaviour
    {
        protected void Start()
        {
            EntityHolder.Load();
        }

        protected void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                EntityHolder.Save();

            if (Input.GetKeyDown(KeyCode.A))
            {
                PlayerPrefs.DeleteAll();
                EntityHolder.Clear();
            }

            if (Input.GetKeyDown(KeyCode.L))
                EntityHolder.Load();
        }
    }
}