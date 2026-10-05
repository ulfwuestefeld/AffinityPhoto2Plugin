# Third-party software notices

The release package includes the components listed below when they are present in the Logi Plugin Service build output. Their exact assembly versions and SHA-256 hashes are recorded in `metadata/sbom.cdx.json` inside the `.lplug4` package.

| Component | License | Source |
| --- | --- | --- |
| ExCSS | MIT | <https://github.com/TylerBrinks/ExCSS> |
| Json.NET | MIT | <https://github.com/JamesNK/Newtonsoft.Json> |
| ShimSkiaSharp | MIT | <https://github.com/wieslawsoltes/Svg.Skia> |
| SkiaSharp | MIT | <https://github.com/mono/SkiaSharp> |
| Svg.Custom | Microsoft Public License (MS-PL) | <https://github.com/wieslawsoltes/Svg.Skia> |
| Svg.Model | MIT | <https://github.com/wieslawsoltes/Svg.Skia> |
| Svg.Skia | MIT | <https://github.com/wieslawsoltes/Svg.Skia> |
| websocket-sharp | MIT | <https://github.com/sta/websocket-sharp> |
| YamlDotNet | MIT | <https://github.com/aaubry/YamlDotNet> |

`PluginApi.dll` and `LogiEventTracing.dll` are Logitech Plugin Service components, not FOSS dependencies. They are supplied by the installed host SDK and are included in the plugin package only as required by the SDK's generated C# project structure. No open-source license is asserted for those components; their distribution remains subject to the Logitech host software terms.

## MIT License

Copyright notices for the MIT-licensed components include:

- ExCSS: Tyler Brinks
- Json.NET: James Newton-King
- ShimSkiaSharp, Svg.Model, and Svg.Skia: Wiesław Šoltés
- SkiaSharp: Xamarin, Inc.; Microsoft Corporation
- websocket-sharp: sta.blockhead
- YamlDotNet: Antoine Aubry and contributors

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

## Microsoft Public License (MS-PL)

Copyright © Wiesław Šoltés 2024.

This license governs use of the accompanying software. If you use the software, you accept this license. If you do not accept the license, do not use the software.

### 1. Definitions

The terms "reproduce," "reproduction," "derivative works," and "distribution" have the same meaning here as under U.S. copyright law. A "contribution" is the original software, or any additions or changes to the software. A "contributor" is any person that distributes its contribution under this license. "Licensed patents" are a contributor's patent claims that read directly on its contribution.

### 2. Grant of Rights

**(A) Copyright Grant.** Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free copyright license to reproduce its contribution, prepare derivative works of its contribution, and distribute its contribution or any derivative works that you create.

**(B) Patent Grant.** Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free license under its licensed patents to make, have made, use, sell, offer for sale, import, and/or otherwise dispose of its contribution in the software or derivative works of the contribution in the software.

### 3. Conditions and Limitations

**(A) No Trademark License.** This license does not grant you rights to use any contributors' name, logo, or trademarks.

**(B)** If you bring a patent claim against any contributor over patents that you claim are infringed by the software, your patent license from such contributor to the software ends automatically.

**(C)** If you distribute any portion of the software, you must retain all copyright, patent, trademark, and attribution notices that are present in the software.

**(D)** If you distribute any portion of the software in source code form, you may do so only under this license by including a complete copy of this license with your distribution. If you distribute any portion of the software in compiled or object code form, you may only do so under a license that complies with this license.

**(E)** The software is licensed "as-is." You bear the risk of using it. The contributors give no express warranties, guarantees, or conditions. You may have additional consumer rights under your local laws which this license cannot change. To the extent permitted under your local laws, the contributors exclude the implied warranties of merchantability, fitness for a particular purpose and non-infringement.

The FOSS identifiers and source links in `FOSS-LICENSES.json` are the release inventory input. A newly shipped DLL without an inventory entry, a missing required DLL, or an SDK component older than the documented minimum stops package generation so the inventory can be reviewed.
