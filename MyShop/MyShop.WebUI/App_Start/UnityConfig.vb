Imports System
Imports Microsoft.Practices.Unity
Imports Microsoft.Practices.Unity.Configuration
Imports MyShop.Core
Imports MyShop.DataAccess.InMemory
Imports Unity

''' <summary>
''' Specifies the Unity configuration for the main container.
''' </summary>
Public Class UnityConfig
#Region "Unity Container"
    Private Shared ReadOnly _Container As Lazy(Of IUnityContainer) = New Lazy(Of IUnityContainer)(
        Function()
            Dim container = New UnityContainer()
            RegisterTypes(container)
            Return container
        End Function)

    ''' <summary>
    ''' Gets the configured Unity container.
    ''' </summary>
    Public Shared Function GetConfiguredContainer() As IUnityContainer
        Return _Container.Value
    End Function
#End Region

    ''' <summary>Registers the type mappings with the Unity container.</summary>
    ''' <param name="container">The unity container to configure.</param>
    ''' <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
    ''' change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
    Public Shared Sub RegisterTypes(container As IUnityContainer)

        ' NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
        ' container.LoadConfiguration()

        ' TODO: Register your types here
        ' container.RegisterType(Of IProductRepository, ProductRepository)()
        container.RegisterType(Of IRepository(Of Product), InMemoryRepository(Of Product))()
        container.RegisterType(Of IRepository(Of ProductCategory), InMemoryRepository(Of ProductCategory))()
    End Sub

End Class