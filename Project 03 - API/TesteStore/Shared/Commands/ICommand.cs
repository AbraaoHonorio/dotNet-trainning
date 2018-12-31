using System;
using System.Collections.Generic;
using System.Text;

namespace TesteStore.Shared.Command
{
    public interface ICommand
    {
         bool IsValid();
    }
}
