#/bin/bash

rm -r ./Game
dotnet ef dbcontext scaffold "Data Source=Databases/item.db_" Microsoft.EntityFrameworkCore.Sqlite --data-annotations --output-dir Game/Item --context-dir Game  --msbuildprojectextensionspath ../artifacts/obj/Server.Database
dotnet ef dbcontext scaffold "Data Source=Databases/live.db_" Microsoft.EntityFrameworkCore.Sqlite --data-annotations --output-dir Game/Live --context-dir Game --msbuildprojectextensionspath ../artifacts/obj/Server.Database
dotnet ef dbcontext scaffold "Data Source=Databases/museum.db_" Microsoft.EntityFrameworkCore.Sqlite --data-annotations --output-dir Game/Museum --context-dir Game --msbuildprojectextensionspath ../artifacts/obj/Server.Database
dotnet ef dbcontext scaffold "Data Source=Databases/unit.db_" Microsoft.EntityFrameworkCore.Sqlite --data-annotations --output-dir Game/Unit --context-dir Game --msbuildprojectextensionspath ../artifacts/obj/Server.Database
dotnet ef dbcontext scaffold "Data Source=Databases/live_notes.db_" Microsoft.EntityFrameworkCore.Sqlite --data-annotations --output-dir Game/LiveNotes --context-dir Game --msbuildprojectextensionspath ../artifacts/obj/Server.Database
