
const { createApp } = Vue;

createApp({
    data() {
        return {
            aluno: dataView || {}
        };
    },
    methods: {
        async addMatricula() {

            const formData = {
                alunoId: this.aluno.alunoId,
                cursoId: this.aluno.cursoId
            };


            try {
                const response = await fetch('/Matricula/Create/', {
                    method: 'POST',
                    headers: {
                        'RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val(),
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(formData)
                });
                
                
                if (!response.ok) {
                    alert('erro ao matricular aluno')
                }
                else {
                    const data = await response.json()
                    if (data.status)
                        window.location.href = `/Matricula/Index/${data.alunoId}`
                    else
                        alert('erro ao matricular aluno')
                }

            } catch (error) {

                alert('Erro ao matricular aluno')
            }
        },
        async excluirMatricula(alunoId, semestre, cursoId) {

            const formData = {
                alunoId: alunoId,
                cursoId: cursoId,
                semestre: semestre
            };

            try {
                const response = await fetch('/Matricula/Delete/', {
                    method: 'DELETE',
                    headers: {
                        'RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val(),
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(formData)
                });


                if (!response.ok) {
                    alert('erro ao excluir aluno')
                }
                else {
                    const data = await response.json()
                    if (data.status)
                        window.location.href = `/Matricula/Index/${data.alunoId}`
                    else
                        alert('erro ao excluir aluno')
                }

            } catch (error) {

                alert('Erro ao excluir matrícula');
            }
        },
        cancelar() {
            window.location.href = '/Home/Index'
        }
    }
}).mount('#app');