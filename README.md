# Raggy Application

## Description
Raggy is an AI-powered application leveraging Semantic Kernel and Ollama for local model inference. It demonstrates integration with local LLMs via Ollama and provides knowledge base processing capabilities for document analysis and question-answering workflows.

## Prerequisites
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) installed.
- [Ollama](https://ollama.ai/) installed (run `curl -fsSL https://raw.githubusercontent.com/ollama/ollama/main/install.sh | sh`)

## Running the Program

1. **Option 1: Run directly using .NET CLI**
   ```bash
   dotnet run
   ```
   This will compile and execute the application from the source files.

2. **Option 2: Run pre-built executable**
   Navigate to the `bin/Debug/net9.0` directory and execute:
   ```bash
   dotnet Raggy.dll
   ```

## Project Structure
- `Program.cs`: Main entry point of the application.
- `Raggy.csproj`: Project configuration file.
- `knowledge_base/`: Contains example data files (e.g., `example.txt`).

## Dependencies
The project uses the following key libraries (automatically restored via .csproj):
- Azure AI SDK
- ClosedXML (Excel handling)
- Semantic Kernel
- OllamaSharp
- OpenAI .NET bindings

## Notes
- Ensure required API keys (e.g., OpenAI, Azure) are configured via environment variables or appsettings.json if applicable.
- The application may require additional configuration based on its intended use case.
