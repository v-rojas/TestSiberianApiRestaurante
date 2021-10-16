using ApiRestaurante.Models;
using System.Collections.Generic;

namespace ApiRestaurante.Interfaces
{
    public interface ICrudRestaurante
    {
        List<Restaurante> SpMetodos(Restaurante restaurante);
    }
}
