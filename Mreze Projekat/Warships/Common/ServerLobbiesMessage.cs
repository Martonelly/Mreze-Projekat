using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    internal class ServerLobbies
    {

        public ushort NumOfLobbies;
         
        public List<ushort> PlayersPerLobby;

        public ServerLobbies() { }
        public ServerLobbies(ushort numOfLobbies, List<ushort> playersPerLobby)
        {
            NumOfLobbies = numOfLobbies;
            PlayersPerLobby = playersPerLobby;
        }

        //server->client

        //ServerLobbies sl=ServerLobbies(5, new List<ushort>(3,2,1,2,0));

        //using (MemoryStream ms = new MemoryStream())
        // {
        //     formatter.Serialize(ms, sl);
        //     byte[] data = ms.ToArray();
        //
        //      player1Socket.Send(data.Length);
        //
        //      player1Socket.Send(data);
        // }

        //ClientSide:

        // messageLenght=serverSocket.recv(buffer,1);

        //    recivedBytes =serversocket.Recv(buffer,messageLength);

        //using (MemoryStream ms = new MemoryStream(buffer, 0, brBajta))
        //        {
        //      ServerLobbies rezultat = (ServerLobbies)formatter.Deserialize(ms);
        //           
        //  rezultat.numOfLobbies -> dinamikusan kirajzolsz 5 boxot ahol valasztod a lobbikat
        //}


    }   //


}
