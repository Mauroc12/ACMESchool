using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Domain.Entities
{
    public class Inscription
    {
        public int Id { get; private set; }
        public Student Student { get; private set; }

        public Course Course { get; private set; }

    }
}
