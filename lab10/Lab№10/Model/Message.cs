using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10.Model
{
    public class Message
    {
        private int id;
        private string sender;
        private string retriever;
        private string text;
        public int Id { get => id; }
        public string Sender { get => sender; }
        public string Retriever { get => retriever; }
        public string Text { get => text; }
        public Message(string sender, string retriever, string text, int id)
        {
            this.sender = sender;
            this.retriever = retriever;
            this.text = text;
            this.id = id;
        }
    }
}
