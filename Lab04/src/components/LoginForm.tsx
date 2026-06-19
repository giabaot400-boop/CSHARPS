import { useState, type FormEvent } from 'react'

// @ts-ignore (Ép TypeScript bỏ qua lỗi đòi đuôi file)
import InputField from './InputField'

export interface LoginPayload {
  username: string
  password: string
}

type SubmitHandler = (payload: LoginPayload) => Promise<void> | void

interface LoginFormProps {
  title: string
  onSubmit: SubmitHandler
}

interface LoginErrors {
  username?: string
  password?: string
}

function LoginForm({ title, onSubmit }: LoginFormProps) {
  const [username, setUsername] = useState<string>('')
  const [password, setPassword] = useState<string>('')
  const [errors, setErrors] = useState<LoginErrors>({})

  const validate = (): LoginErrors => {
    const newErrors: LoginErrors = {}
    if (!username.trim()) newErrors.username = 'Vui long nhap ten...'
    if (!password.trim()) newErrors.password = 'Vui long nhap mat khau'
    else if (password.length < 4) newErrors.password = 'Toi thieu 4 ky tu'
    return newErrors
  }

  const handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    
    const validationErrors = validate()
    if (Object.keys(validationErrors).length > 0) {
      setErrors(validationErrors)
      return
    }
    
    setErrors({})
    onSubmit({ username, password })
  }

  return (
    <form className="login-form" onSubmit={handleSubmit}>
      <h2 className="form-title">{title}</h2>

      <InputField
        label="Ten dang nhap"
        type="text"
        value={username}
        // Thêm e: any để dập tắt cảnh báo của TypeScript
        onChange={(e: any) => setUsername(e.target.value)}
        placeholder="Nhap ten dang nhap..."
        error={errors.username}
      />

      <InputField
        label="Mat khau"
        type="password"
        value={password}
        // Thêm e: any để dập tắt cảnh báo của TypeScript
        onChange={(e: any) => setPassword(e.target.value)}
        placeholder="Nhap mat khau..."
        error={errors.password}
      />

      <button type="submit" className="login-btn">
        Dang nhap
      </button>
    </form>
  )
}

export default LoginForm