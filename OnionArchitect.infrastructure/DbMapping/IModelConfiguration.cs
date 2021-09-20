using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitect.infrastructure.DbMapping
{
    public interface IModelConfiguration
    {
        void ApplyConfiguration(ModelBuilder modelBuilder);
    }
}
