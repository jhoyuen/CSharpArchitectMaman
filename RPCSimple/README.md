## RPCSimple Solution

This repository demonstrates a simple gRPC-based Remote Procedure Call (RPC) system in C# using .NET 8. It consists of two main projects: a server and a client, both communicating using protocol buffers defined in `calculator.proto`.

### Purpose

The purpose of this solution is to provide a minimal example of how to implement a gRPC service and client in C#. The service exposes a simple calculator with an `Add` operation, allowing the client to send two numbers and receive their sum from the server.

### Projects

#### RPCSimpleExample
**Path:** `RPCSimpleExample/RPCSimpleExample.csproj`

This is the gRPC server project. It hosts the Calculator service defined in `calculator.proto` and listens for incoming RPC requests on port 50051. The server implements the `Add` method, which takes two integers and returns their sum. The server uses the `Grpc.Core` library and the generated code from the protocol buffer definition.

#### RPCSimpleClient
**Path:** `RPCSimpleClient/RPCSimpleClient.csproj`

This is the gRPC client project. It connects to the Calculator service running on `localhost:50051` and sends an `Add` request with two numbers. The client receives and prints the result. Like the server, it uses the `Grpc.Core` library and the generated code from `calculator.proto`.

### Protocol Definition

The `calculator.proto` file defines the Calculator service and messages used for communication. Both projects reference this file for code generation.

---
This solution is intended for educational purposes and as a starting point for building more complex gRPC-based systems in .NET.

### Usage

1. **Build the Solution**

   Ensure you have .NET 8 SDK installed. Build the solution using Visual Studio or with the command:

   ```sh
   dotnet build
   ```

2. **Run the Server**

   Start the gRPC server by running the `RPCSimpleExample` project:

   ```sh
   dotnet run --project RPCSimpleExample/RPCSimpleExample.csproj
   ```

   The server will listen on port 50051.

3. **Run the Client**

   In a new terminal, run the `RPCSimpleClient` project:

   ```sh
   dotnet run --project RPCSimpleClient/RPCSimpleClient.csproj
   ```

   The client will send an Add request (5 + 3) to the server and print the result.

---
This solution is intended for educational purposes and as a starting point for building more complex gRPC-based systems in .NET.
