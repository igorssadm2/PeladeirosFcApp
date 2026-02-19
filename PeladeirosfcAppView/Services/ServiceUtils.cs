using PeladeirosfcApp.Shared.ViewToApiDTO;

namespace PeladeirosfcAppView.Services
{
    public static class ServiceUtils
    {
        /// <summary>
        /// Gera dados fake para testes de cadastro de usuário
        /// </summary>
        public static UsuarioDto GerarDadosFakeUsuario()
        {
            var random = new Random();
            var nomes = new[] { "João Silva", "Maria Santos", "Pedro Oliveira", "Ana Costa", "Carlos Souza", 
                               "Julia Pereira", "Lucas Almeida", "Beatriz Lima" };
            var apelidos = new[] { "Neymar", "Ronaldinho", "Pelé", "Zico", "Romário", "Kaká", "Rivaldo", "Ronaldo" };
            var generos = new[] { "Masculino", "Feminino", "Outro" };
            var pesDominantes = new[] { "Direito", "Esquerdo", "Ambidestro" };
            var posicoes = new[] { "Goleiro", "Zagueiro", "Lateral Direito", "Lateral Esquerdo", "Volante", 
                                   "Meio-campo", "Meia Atacante", "Ponta Direita", "Ponta Esquerda", "Centroavante" };

            var randomId = random.Next(1000, 9999);
            var apelido = apelidos[random.Next(apelidos.Length)];

            return new UsuarioDto
            {
                Nome = nomes[random.Next(nomes.Length)],
                Email = $"{apelido.ToLower()}{randomId}@teste.com",
                Telefone = $"(11) {random.Next(90000, 99999)}-{random.Next(1000, 9999)}",
                Apelido = apelido,
                DataNascimento = DateTime.Now.AddYears(-random.Next(18, 40)),
                Genero = generos[random.Next(generos.Length)],
                PeDominante = pesDominantes[random.Next(pesDominantes.Length)],
                Posicao = posicoes[random.Next(posicoes.Length)],
                Altura = random.Next(160, 195),
                Peso = random.Next(60, 100),
                TamanhoPe = random.Next(38, 45),
                Cidade = "São Paulo",
                Bairro = "Centro",
                CEP = $"{random.Next(10000, 99999)}-{random.Next(100, 999)}"
            };
        }

        /// <summary>
        /// Gera dados fake simplificados apenas com campos obrigatórios do SignUp
        /// </summary>
        public static (string Nome, string Email, string? Telefone, string? Apelido, DateTime? DataNascimento, 
                       string? Genero, string? PeDominante, string? Posicao) GerarDadosFakeSignUp()
        {
            var random = new Random();
            var nomes = new[] { "João Silva", "Maria Santos", "Pedro Oliveira", "Ana Costa", "Carlos Souza", 
                               "Julia Pereira", "Lucas Almeida", "Beatriz Lima" };
            var apelidos = new[] { "Neymar", "Ronaldinho", "Pelé", "Zico", "Romário", "Kaká", "Rivaldo", "Ronaldo" };
            var generos = new[] { "Masculino", "Feminino", "Outro" };
            var pesDominantes = new[] { "Direito", "Esquerdo", "Ambidestro" };
            var posicoes = new[] { "Goleiro", "Zagueiro", "Lateral Direito", "Lateral Esquerdo", "Volante", 
                                   "Meio-campo", "Meia Atacante", "Ponta Direita", "Ponta Esquerda", "Centroavante" };

            var randomId = random.Next(1000, 9999);
            var apelido = apelidos[random.Next(apelidos.Length)];

            return (
                Nome: nomes[random.Next(nomes.Length)],
                Email: $"{apelido.ToLower()}{randomId}@teste.com",
                Telefone: $"(11) {random.Next(90000, 99999)}-{random.Next(1000, 9999)}",
                Apelido: apelido,
                DataNascimento: DateTime.Now.AddYears(-random.Next(18, 40)),
                Genero: generos[random.Next(generos.Length)],
                PeDominante: pesDominantes[random.Next(pesDominantes.Length)],
                Posicao: posicoes[random.Next(posicoes.Length)]
            );
        }
    }
}
