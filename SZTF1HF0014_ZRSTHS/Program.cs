using System;

namespace SZTF1HF0014_ZRSTHS
{
    class Task
    {
        public int id;
        public int completionTime;
        public int availabilityTime;

        public Task(int id, int availabilityTime, int completionTime)
        { 
            this.id = id;
            this.availabilityTime=availabilityTime;
            this.completionTime=completionTime;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Task[] tasks = Input();
            Console.WriteLine(Simulate(tasks).TrimEnd(','));
        }
        static string Simulate(Task[] tasks)
        {
            int time = 0;
            int remainingTime = 0;
            bool isRunning = true;
            bool isIdle = true;
            int taskCount = tasks.Length;

            Task[] orderedTasks = SortTasks(tasks);
            string output = "";

            while (isRunning && taskCount > 0)
            {
                time++;
                Task task = FindAvailableTask(orderedTasks, time);

                if (task != null && isIdle)
                {
                    isIdle = false;
                    remainingTime = task.completionTime;
                    orderedTasks = RemoveFromArray(orderedTasks, task);
                    output += task.id + ",";
                }

                if (!isIdle)
                {
                    remainingTime--;
                    if (remainingTime == 0)
                    {
                        taskCount--;
                        isIdle = true;
                    }
                }
            }
            return output;
        }

        static Task[] RemoveFromArray(Task[] tasks, Task task)
        {
            Task[] tmp = tasks;
            for (int i = 0; i < tmp.Length; i++)
            {
                if (tmp[i]==task)
                {
                    tmp[i] = null;
                }
            }

            return tmp;
        }

        static Task FindAvailableTask(Task[] tasks, int time)
        {
            for (int i = 0; i < tasks.Length; i++)
            {
                if (tasks[i]!= null && time >= tasks[i].availabilityTime){ return tasks[i]; }
            }
            return null;
        }

        static Task[] SortTasks(Task[] tasks)
        {
            for (int i = tasks.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (tasks[j].completionTime > tasks[j + 1].completionTime)
                    {
                        Task tmp = tasks[j];
                        tasks[j] = tasks[j + 1];
                        tasks[j + 1] = tmp;
                    }
                }
            }
            return tasks;
        }

        static Task[] Input()
        {
            Task[] tasks = new Task[int.Parse(Console.ReadLine())];
            for (int i = 0; i < tasks.Length; i++)
            {
                string[] input = Console.ReadLine().Split(',');
                Task task = new Task(i, int.Parse(input[0]), int.Parse(input[1]));
                tasks[i] = task;
            }
            return tasks;
        }
    }
}
