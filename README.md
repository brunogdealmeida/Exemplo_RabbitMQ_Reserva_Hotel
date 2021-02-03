# Exemplo_RabbitMQ_Reserva_Hotel
No exemplo desse repositório temos um exemplo de aplicação console C# criada para demostrar o conceito de mensageria utilizando RabbitMQ.

Esse exemplo foi criado utilizando:

Net Core 3.1
RabbitMQ 5.2
Necessário possui o Erlang instalado na máquina. Link: https://www.erlang.org/downloads
Necessário instalar a versão do RabbitMQ para Windows. https://www.rabbitmq.com/download.html
Note que para que o exemplo desse repositorio possa ser executado na sua máquina local é necessário que sejam feiras as seguintes configurações:

Configurar o usuário e senha do Painel do RabbitMQ
Criar uma fila no Painel do RabbitMQ com o nome Registry, caso use um nome diferente será necessário alterar o nome da fila no código fonte.
Esse exemplo consiste no seguinte cenário:

O Hotel ABC recebe solicitação de reservas para seus quartos. Quando o produtor das mensagens (ReservaHotel) é executado ele pergunta ao usuário quantos quartos serão reservados e realiza o registro da reserva de cada hotel. Esses registros são enviados para o setor de Administração do Hotel para que o mesmo possa efetuar a confirmação da reserva.

Quando a aplicação do produtor é executada ela exibe na tela as mensagens da confirmação de cada registro e quando o consumidor (AdministracaoHotel) é executado ele lê as mensagens na fila Registry e exibe a mensagem da confirmação de cada reserva.

Essa aplicação é um exemplo conceitual que tem como objetivo servir como base para um post do meu blog em um futuro próximo, a implementação atual está longe de ser algo funcional, o objetivo atual é que seja utilizado com fins de aprendizado.

:)
