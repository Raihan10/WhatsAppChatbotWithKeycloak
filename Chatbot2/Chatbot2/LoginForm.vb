Public Class LoginForm
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim loginFailMsg As String = "Username or Password is wrong. Please try again."
        Dim http As New Chilkat.Http
        Dim req As New Chilkat.HttpRequest
        If (txtboxPassword.Text <> "" And txtboxUsername.Text <> "") Then

            Dim res As New Chilkat.HttpResponse
            req.AddParam("grant_type", "password")
            req.AddParam("client_id", "nodejs-microservice")
            req.AddParam("client_secret", "73749498-628b-4894-b39f-d876551f176b")
            req.AddParam("username", txtboxUsername.Text)
            req.AddParam("password", txtboxPassword.Text)
            res = http.PostUrlEncoded("http://localhost:8080/auth/realms/Demo-Realm/protocol/openid-connect/token", req)

            If (http.LastMethodSuccess <> True) Then
                Debug.WriteLine(http.LastErrorText)
                Exit Sub
            End If

            If (res.StatusCode = 200) Then
                Dim bodyJson As New Chilkat.JsonObject With {
                    .EmitCompact = False
                }
                bodyJson.Load(res.BodyStr)
                Dim accessToken As String = bodyJson.StringOf("access_token")
                'MessageBox.Show(accessToken)

                'Authenticate Token
                Dim bearerToken As String = "bearer " & accessToken
                http.SetRequestHeader("Authorization", bearerToken)
                Dim resAuth As New Chilkat.HttpResponse
                resAuth = http.QuickGetObj("http://localhost:8000/test/all-user")

                If (resAuth.StatusCode = 200) Then
                    Dim form1 As New Form1
                    form1.Show()
                    'Me.Close()
                    Me.Hide()
                Else
                    MessageBox.Show(loginFailMsg)
                    txtboxUsername.Text = ""
                    txtboxPassword.Text = ""
                End If
            Else
                MessageBox.Show(loginFailMsg)
                txtboxUsername.Text = ""
                txtboxPassword.Text = ""
            End If
        Else
        MessageBox.Show("Please input username and password to login")
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class