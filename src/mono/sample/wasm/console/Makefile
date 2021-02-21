TOP=../../../../..

include ../wasm.mk

override MSBUILD_ARGS+=/p:RunAOTCompilation=true /p:AOTProfilePath=$(PROFILE_PATH) /bl

ifneq ($(V),)
DOTNET_MONO_LOG_LEVEL=--setenv=MONO_LOG_LEVEL=debug
endif

PROJECT_NAME=Wasm.Console.Sample.csproj

run: run-console
