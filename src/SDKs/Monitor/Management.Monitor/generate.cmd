::
:: Microsoft Azure SDK for Net - Generate library code
:: Copyright (C) Microsoft Corporation. All Rights Reserved.
::

@echo off
call %~dp0..\..\..\..\tools\generate.cmd monitor/resource-manager %*
call %~dp0..\..\..\..\tools\generate.cmd monitor/data-plane %*