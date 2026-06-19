import type { ChangeEventHandler } from 'react'

type InputType = 'text' | 'password'

// Khai báo kiểu dữ liệu chặt chẽ cho các Props truyền vào
interface InputFieldProps {
  label: string
  type: InputType
  value: string
  onChange: ChangeEventHandler<HTMLInputElement>
  placeholder?: string
  error?: string
}

// Component InputField -- nhận dữ liệu qua PROPS
function InputField({
  label,
  type,
  value,
  onChange,
  placeholder,
  error,
}: InputFieldProps) {
  return (
    <div className="input-group">
      <label className="input-label">{label}</label>
      <input
        type={type}
        value={value}
        onChange={onChange}
        placeholder={placeholder}
        className={`input-field ${error ? 'input-error' : ''}`}
      />
      {/* Hiển thị lỗi nếu có */}
      {error && <span className="error-msg">{error}</span>}
    </div>
  )
}

export default InputField