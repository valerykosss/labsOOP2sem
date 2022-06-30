using Lab_13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_13.Repository
{
    public class ConsultationRepository : IRepository<Consultation>
    {
        private Context.Context context;
        public ConsultationRepository(Context.Context context)
        {
            this.context = context;
        }

        public void Delete(Consultation entity)
        {
            context.Consultations.Remove(entity);
        }

        public Consultation Get(int id)
        {
            return context.Consultations.Find(id);
        }

        public IEnumerable<Consultation> GetAll()
        {
            return context.Consultations;
        }

        public void Insert(Consultation entity)
        {
            context.Consultations.Add(entity);
        }

        public void Remove(int id)
        {
            context.Consultations.Remove(Get(id));
        }

        public void Update(Consultation entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
