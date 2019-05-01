using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaComum.produto
{
    class ProdutoNegocio : ProdutoInterface
    {
        public void delete(Produto produto)
        {
            new ProdutoDados().delete(produto);
        }

        public void insert(Produto produto)
        {
            new ProdutoDados().insert(produto);
        }

        public List<Produto> list(Produto produto)
        {
            return new ProdutoDados().list(produto);
        }

        public void update(Produto produto)
        {
            new ProdutoDados().update(produto);
        }
    }
}
