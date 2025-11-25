//Marcos Vinicius Arruda Vandresen
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace AcademiaDoZe.Presentation.AppMaui.Message
{
    public sealed class BancoPreferencesUpdatedMessage(string value) : ValueChangedMessage<string>(value)
    {
    }
}
// ValueChangedMessage<T> é uma classe base do toolkit para mensagens que carregam um valor.