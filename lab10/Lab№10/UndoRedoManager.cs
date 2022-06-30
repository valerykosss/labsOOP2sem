using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10
{
    public static class UndoRedoManager
    {
        private static int state = -1;
        private static List<List<Model.Message>> chatManager = new List<List<Model.Message>>();

        public static List<Model.Message> Undo()
        {
            state--;
            return chatManager[state];
        }

        public static List<Model.Message> Redo()
        {
            state++;
            return chatManager[state];
        }

        public static void Add(List<Model.Message> games)
        {
            chatManager.Add(games);
            state++;
        }
        public static int State { get => state; }
        public static int Length { get => chatManager.Count; }
    }
}
