/**


Limited to 300 Words in from the document


**/

#pragma warning disable SKEXP0001, SKEXP0003, SKEXP0010, SKEXP0011, SKEXP0050, SKEXP0052, SKEXP0070

using Microsoft.KernelMemory; 
using Microsoft.KernelMemory.AI.Ollama; 
using Microsoft.SemanticKernel; 
using Microsoft.SemanticKernel.Connectors.Ollama;

/**
*
Description:
*
*       - This is the entry point of the program.
*
Key concepts:
*
*       - Main method, async, await
*
*/
var ollamaEndpoint = "http://localhost:11434"; 
var modelIdChat = "llama3.2:3b"; 
var modelIdEmbeddings = "bge-m3:567m"; 

/**
*
Description:
*
*       - This code prompts the user to enter a question.
*
Key concepts:
*
*       - Console input
*
*/
Console.WriteLine("Please enter your question: ");
var question = Console.ReadLine();
if (string.IsNullOrWhiteSpace(question))
{
    question = "What is the name of the character in the txt file?";
} 

/**
*
Description:
*
*       - This code displays the title of the program and the question that will be asked to the model.
*
Key concepts:
*
*       - Console output, string interpolation
*
*/
Console.WriteLine($"Using model: {modelIdChat}");
Console.WriteLine($"Question: {question}");



// Create kernel with Ollama chat completion configuration
var builder = Kernel.CreateBuilder().AddOllamaChatCompletion(
    modelId: modelIdChat,
    endpoint: new Uri(ollamaEndpoint)); 

Kernel kernel = builder.Build(); 

/**

*/
var configOllamaKernelMemory = new OllamaConfig
{
    Endpoint = ollamaEndpoint, 
    TextModel = new OllamaModelConfig(modelIdChat),
    EmbeddingModel = new OllamaModelConfig(modelIdEmbeddings, 2048) 
};

/**
*
Description:
*
*       - This code creates a new instance of the KernelMemoryBuilder class.
*
Key concepts:
*
*       - object initialization
*
*/

var memory = new KernelMemoryBuilder() 
    .WithOllamaTextGeneration(configOllamaKernelMemory) 
    .WithOllamaTextEmbeddingGeneration(configOllamaKernelMemory) 
    .Build(); 


/**
*
Description:
*
*       - This code imports the dummy.txt and dummy.pdf files into the memory.
*
Key concepts:
*
*       - async, await, file import
*
*/
string[] files = Directory.GetFiles("knowledge_base");
foreach (var file in files)
{
    var documentId = Path.GetFileNameWithoutExtension(file);
    await memory.ImportDocumentAsync(file, documentId: documentId);
}
/*
Console.WriteLine("Loading files...");
await memory.ImportDocumentAsync("colin.pdf");
await memory.ImportDocumentAsync("dum1.pdf"); // Uncommented
*/

Console.WriteLine("Asking question with memory...");
var answer = memory.AskStreamingAsync(question); 
await foreach (var result in answer)
{
    Console.Write(result.ToString());
}

Console.WriteLine();

