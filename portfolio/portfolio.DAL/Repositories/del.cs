using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.DAL.Repositories
{
    class del
    {
    }
}


CoursesContext context;

public GroupsRepository(CoursesContext context)
{
    this.context = context;
}

public void Create(Group t)
{
    context.Groups.Add(t);
}