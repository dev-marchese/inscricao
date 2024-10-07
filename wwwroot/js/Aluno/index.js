
const { createApp } = Vue;

createApp({
    data() {
        return {
            aluno: dataView
        };
    },
    methods: {
        async addAluno() {
            const formData = {
                nome: this.aluno.nome,
                email: this.aluno.email,
                cpf: this.aluno.cpf,
                alunoId: this.aluno.alunoId
            };

            try {
                const response = await fetch('/Aluno/Create/', {
                    method: 'POST',
                    headers: {
                        'RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val(),
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(formData)
                });


                if (!response.ok) {
                    alert('erro ao inserir aluno')
                }
                else {
                    const data = await response.json()
                    if (data.status)
                        window.location.href = `/Aluno/Index/${data.alunoId}`
                    else
                        alert('erro ao inserir aluno')
                }

            } catch (error) {

                alert('erro')
            }
        },
        cancelar() {
            window.location.href = '/Home/Index'
        }
    }
}).mount('#app');