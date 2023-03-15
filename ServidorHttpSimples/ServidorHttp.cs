using System.Net.Sockets;
using System.Net;

// link video https://www.youtube.com/watch?v=1b0ot7xaJ00
// minuto 12.2

class ServidorHttp {
    private TcpListener? Controlador {get; set;}
    private int Porta {get; set;}
    private int QtdeRequisicoes {get; set;}

    public ServidorHttp(int porta = 8000){
        this.Porta = porta;
        try {
            Controlador = new TcpListener(IPAddress.Parse("127.0.1"), Porta);
            Controlador.Start();
            Console.WriteLine($"O Servidor pode ser acessado em 127.0.1:{this.Porta}");
        } catch (Exception e) {
            Console.WriteLine($"Servidor não pode ser inicializado! \n{e.Message} ");
        }
    }

    private async Task aguardarRequisicoes() {
        while(true) {
            Socket conexao = await this.Controlador.AcceptSocketAsync();
            QtdeRequisicoes++;
        }
    }

    private void processaRequisicoes(Socket conexao, int numeroRequisicao) {
        Console.WriteLine($"Processando request #{numeroRequisicao}");
    }

}