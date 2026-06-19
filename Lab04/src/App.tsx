import { useState } from 'react'

// @ts-ignore
import LoginForm from './components/LoginForm'
// @ts-ignore
import './App.css'

// Khai báo các trạng thái có thể xảy ra của ứng dụng
type LoginStatus = 'idle' | 'loading' | 'success' | 'error'

interface LoginPayload {
  username: string
  password: string
}

interface LoginResponse {
  message: string
}

// ===== Hàm giả lập API bằng PROMISE =====
function fakeLoginAPI(username: string, password: string): Promise<LoginResponse> {
  return new Promise((resolve, reject) => {
    // Giả lập độ trễ mạng 1.5 giây
    setTimeout(() => {
      if (username === 'admin' && password === '1234') {
        resolve({ message: `Xin chao, ${username}!` }) // Thành công
      } else {
        reject(new Error('Sai tai khoan hoac mat khau!')) // Thất bại
      }
    }, 1500)
  })
}

function App() {
  // useState: quản lý trạng thái của app
  const [status, setStatus] = useState<LoginStatus>('idle')
  const [message, setMessage] = useState<string>('')
  const [loggedUser, setLoggedUser] = useState<string | null>(null)

  // ===== async/await: xử lý bất đồng bộ =====
  const handleLogin = async ({ username, password }: LoginPayload): Promise<void> => {
    setStatus('loading')
    setMessage('')

    try {
      // await: Dừng lại chờ Promise (hàm fakeLoginAPI) hoàn thành
      const result = await fakeLoginAPI(username, password)
      
      // Nếu thành công (resolve)
      setStatus('success') 
      setMessage(result.message)
      setLoggedUser(username)
    } catch (error) {
      // Nếu thất bại (reject), bắt lỗi hiển thị ra màn hình
      const errorMessage = error instanceof Error ? error.message : 'Dang nhap that bai'
      setStatus('error') 
      setMessage(errorMessage)
    }
  }

  // Hàm để quay lại màn hình đăng nhập
  const handleLogout = () => {
    setStatus('idle')
    setLoggedUser(null)
    setMessage('')
  }

  // Giao diện hiển thị
  return (
    <div className="app-container">
      {status === 'success' ? (
        // Nếu đăng nhập thành công thì hiện giao diện Welcome
        <div className="welcome-box">
          <h2>{message}</h2>
          <button onClick={handleLogout} className="login-btn">Đăng xuất</button>
        </div>
      ) : (
        // Nếu chưa đăng nhập hoặc lỗi thì hiện Form
        <>
          <LoginForm title="ĐĂNG NHẬP HỆ THỐNG" onSubmit={handleLogin} />
          
          {/* Hiển thị trạng thái đang tải hoặc lỗi */}
          {status === 'loading' && <p style={{ color: 'blue', marginTop: '10px' }}>Đang xử lý (Chờ 1.5s)...</p>}
          {status === 'error' && <p className="error-msg" style={{ color: 'red', marginTop: '10px' }}>{message}</p>}
        </>
      )}
    </div>
  )
}

export default App