impvs
del *.nupkg 
nuGet pack NBitcoin.Tools.csproj -Build -Properties Configuration=Release -includereferencedprojects
(((dir *.nupkg).Name) -match "[0-9]+?\.[0-9]+?\.[0-9]+?\.[0-9]+")
$ver = $Matches.Item(0)
git tag -a "v$ver" -m "$ver"
git push --tags

msbuild.exe ../Build/Build.csproj /p:Configuration=Release
msbuild.exe ../NBitcoin.Tools/NBitcoin.Tools.csproj /p:Configuration=Release
msbuild.exe ../Build/DeployClient.proj