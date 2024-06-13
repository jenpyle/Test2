using System;
using System.Collections.Generic;

namespace Mikron_MOAB_HMI.Nodes
{
    public static class NodeCreationUnitOfWork
    {
        private static readonly List<Action> tasks = new List<Action>();

        public static void AddTask(Action task)
        {
            tasks.Add(task);
        }

        public static void Commit()
        {
            foreach (var task in tasks)
            {
                task(); // Execute each task
            }
        }
    }
}