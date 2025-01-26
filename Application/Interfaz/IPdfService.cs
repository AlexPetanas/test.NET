using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaz
{
    public interface IPdfService
    {
        public Task<string> GetTextString(MemoryStream File);
    }
}
