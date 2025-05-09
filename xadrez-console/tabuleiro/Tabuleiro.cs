namespace tabuleiro {
    internal class Tabuleiro {

        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas) {
            Linhas = linhas;
            Colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca Peca(int linha, int coluna) {
            return pecas[linha, coluna];
        }

        public Peca Peca(Posicao pos) {
            return pecas[pos.linha, pos.coluna];
        }

        public bool ExistePeca(Posicao pos) {
            ValidarPosicao(pos);
            return Peca(pos) != null;
        }

        public void ColocarPeca(Peca p, Posicao pos) {
            if (ExistePeca(pos)) {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }

        public Peca RetirarPeca(Posicao pos) {
            if (Peca(pos) == null) {
                return null;
            }
            Peca aux = Peca(pos);
            aux.posicao = null;
            pecas[pos.linha, pos.coluna] = null;
            return aux;
        }

        public bool PosicaoValida(Posicao pos) {
            return pos.linha >= 0 && pos.linha < Linhas && pos.coluna >= 0 && pos.coluna < Colunas;
        }

        public void ValidarPosicao(Posicao pos) {
            if (!PosicaoValida(pos)) {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}
