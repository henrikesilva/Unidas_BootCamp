const botao = document.getElementsByClassName('enviar')

if (botao && botao.length > 0) {
    botao[0].addEventListener('click', function () {
        const nome = document.getElementById('nome')
        const telefone = document.getElementById('telefone')
        const email = document.getElementById('email')

        nome.setCustomValidity(nome.value == '' ? 'Informe corretamente o nome' : '')
        telefone.setCustomValidity(telefone.value == '' ? 'Informe corretamente o telefone' : '')
        email.setCustomValidity(email.value == '' ? 'Informe corretamente o email' : '')

        if (this.parentElement.id === 'formularioRegistro') {
            const data = document.getElementById('data')
            const masculino = document.getElementById('masculino')
            const feminino = document.getElementById('feminino')
            const desenv = document.getElementById('desenv')
            const negocio = document.getElementById('negocio')
            const vaga = document.getElementById('vaga')

            if (data) {
                data.setCustomValidity(data.value == '' ? 'Informe corretamente a data' : '')
            }

            if (masculino && feminino) {
                masculino.setCustomValidity(masculino.checked == false && feminino.checked == false ? 'Selecione o sexo do registro' : '')
            }

            if (desenv && negocio) {
                desenv.setCustomValidity(desenv.checked == false && negocio.checked == false ? 'Selecione o tipo de vaga desejado' : '')
            }

            if (vaga) {
                vaga.setCustomValidity(vaga.value < 0 ? 'Selecione a vaga desejada' : '')
            }
        } else if (this.parentElement.id === 'formularioContato') {
            const assunto = document.getElementById('assunto')
            
            if (assunto) {
                assunto.setCustomValidity(assunto.value == '' ? 'Informe corretamente o assunto' : '')
            }
        }
    })
} else {
    console.error('Botao com a class enviar nao existe neste HTML')
}