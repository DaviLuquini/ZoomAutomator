# ZoomAutomator API

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-7.0-blue.svg)](https://dotnet.microsoft.com/download)
[![Zoom API](https://img.shields.io/badge/Zoom-API-2D8CFF.svg)](https://marketplace.zoom.us/docs/api-reference/introduction)

A ZoomAutomator API é uma aplicação ASP.NET Core que integra com o Zoom para permitir a criação programática de reuniões instantâneas. O projeto serve como backend para soluções que precisam criar e gerenciar reuniões Zoom automaticamente, com suporte a recursos como transcrição, chat e eventos pós-reunião.

## Funcionalidades

- ✅ Criação de reuniões instantâneas via API (`POST /api/zoom/create-meeting`)
- 🧠 Suporte a transcrição automática (se habilitada na conta Zoom)
- 💬 Captura de mensagens do chat após a reunião
- 📥 Detecção de eventos como encerramento ou cancelamento da reunião

## 🔧 Estrutura

A API é construída com base em princípios de Clean Architecture, com separação clara entre camadas de controle, aplicação e domínio.

### ZoomController

O controlador principal expõe o endpoint `/api/zoom/create-meeting`, que recebe um `CreateMeetingRequest` via POST e chama o serviço `IZoomService` para criar a reunião instantânea.

```csharp
[HttpPost("create-meeting")]
public async Task<IActionResult> CreateMeeting([FromBody] CreateMeetingRequest request)
{
    var result = await _zoomService.CreateInstantMeetingAsync(request);
    return Ok(result);
}
```

### IZoomService

Interface que encapsula a lógica de integração com a API do Zoom, garantindo que a controladora permaneça fina e desacoplada de detalhes de implementação.

```csharp
public interface IZoomService
{
    Task<CreateMeetingResponse> CreateInstantMeetingAsync(CreateMeetingRequest request);
    // Outros métodos relacionados ao Zoom
}
```

## Tecnologias Utilizadas

- ASP.NET Core 7.0
- Zoom REST API
- C#
- Clean Architecture

## 🛠️ Configuração

### Pré-requisitos

- [.NET 7.0 SDK](https://dotnet.microsoft.com/download) ou superior
- Conta no Zoom com permissões para criar OAuth App

### Configuração do Zoom OAuth

1. Acesse o [Zoom App Marketplace](https://marketplace.zoom.us/)
2. Crie um OAuth App com os seguintes escopos:
   - `meeting:write`
   - `meeting:read`
   - `user:read`
3. Configure as URIs de redirecionamento necessárias

### Configuração da Aplicação

Adicione as seguintes configurações ao seu `appsettings.json`:

```json
{
  "Zoom": {
    "ClientId": "seu_client_id",
    "ClientSecret": "seu_client_secret",
    "RedirectUri": "sua_uri_de_redirecionamento",
    "AuthorizationEndpoint": "https://zoom.us/oauth/authorize",
    "TokenEndpoint": "https://zoom.us/oauth/token"
  }
}
```

## Como Executar

1. Clone o repositório
   ```bash
   git clone https://github.com/seu-usuario/ZoomAutomator.git
   cd ZoomAutomator
   ```

2. Restaure os pacotes NuGet
   ```bash
   dotnet restore
   ```

3. Configure as variáveis de ambiente ou o arquivo `appsettings.json`

4. Execute a aplicação
   ```bash
   dotnet run
   ```

A API estará disponível em `https://localhost:5001` por padrão.

## 📋 Uso da API

### Criar uma reunião instantânea

**Endpoint:** `POST /api/zoom/create-meeting`

**Corpo da Requisição:**
```json
{
  "topic": "Reunião de Teste",
  "agenda": "Discussão sobre o projeto",
  "duration": 60,
  "settings": {
    "enableTranscription": true,
    "enableChat": true
  }
}
```

**Resposta:**
```json
{
  "meetingId": "123456789",
  "joinUrl": "https://zoom.us/j/123456789",
  "password": "abcdef",
  "hostKey": "123456"
}
```

## 🔐 Requisitos

- Conta Zoom com OAuth App configurado
- (Opcional) Plano Zoom Pro ou superior para acessar recursos de transcrição automática

## 📄 Licença

Este projeto está licenciado sob a [Licença MIT](LICENSE).
